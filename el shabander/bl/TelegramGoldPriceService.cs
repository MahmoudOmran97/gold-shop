using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TL;
using WTelegram;
using Message = TL.Message;

namespace el_shabander.bl
{
    /// <summary>
    /// نتيجة قراءة آخر سعر ذهب من رسالة قناة "سوق الدهب" على تليجرام.
    /// </summary>
    public class GoldPriceUpdate
    {
        public decimal Buy21 { get; set; }
        public decimal Sell21 { get; set; }
        public DateTime MessageDateUtc { get; set; }
        public string RawText { get; set; }
    }

    /// <summary>
    /// خدمة قراءة آخر سعر ذهب منشور في قناة تليجرام العامة "سوق الدهب".
    ///
    /// طريقة التركيب:
    /// 1) هات api_id و api_hash من https://my.telegram.org
    /// 2) ثبّت المكتبة: Install-Package WTelegramClient
    /// 3) ضيف Reference لـ Microsoft.VisualBasic
    /// 4) عبّي الثوابت تحت (ApiId, ApiHash, PhoneNumber)
    /// 5) أول تشغيل هيطلب منك كود التفعيل اللي بيوصلك على تليجرام (هيظهر Popup لإدخاله)
    ///    بعد كده هيحفظ الجلسة في ملف telegram.session ومش هيطلب تاني.
    ///
    /// الاستخدام:
    ///   var service = new TelegramGoldPriceService();
    ///   var price = await service.GetLatestPriceAsync();
    ///   lblBuy21.Text = price.Buy21.ToString("N2");
    ///   lblSell21.Text = price.Sell21.ToString("N2");
    /// </summary>
    public class TelegramGoldPriceService : IDisposable
    {
        // === عبّي البيانات دي من my.telegram.org وبيانات حسابك ===
        private const string ApiId = "39094010";
        private const string ApiHash = "70dc153ad6988de1b811e80af8f69e79";
        private const string PhoneNumber = "+201004753611"; // ضع رقم تليجرام بتاعك هنا بالكود الدولي (+20)

        // اسم المستخدم بتاع القناة (من رابط t.me/souqeldahb24 -> الاسم هو souqeldahb24)
        private const string ChannelUsername = "souqeldahb24";

        private Client _client;
        private InputPeerChannel _channelPeer;

        /// <summary>
        /// دالة تزود مكتبة WTelegramClient بالبيانات المطلوبة أثناء تسجيل الدخول.
        /// أول مرة بس هتظهر نافذة إدخال كود التفعيل.
        /// </summary>
        private string ConfigCallback(string what)
        {
            switch (what)
            {
                case "api_id":
                    return ApiId;
                case "api_hash":
                    return ApiHash;
                case "phone_number":
                    return PhoneNumber;
                case "verification_code":
                    return ShowInputBox(
                        "ادخل كود التفعيل اللي وصلك على تطبيق تليجرام:",
                        "تفعيل الدخول لتليجرام");
                case "password":
                    // بيتطلب بس لو حسابك مفعل عليه تحقق بخطوتين
                    return ShowInputBox(
                        "ادخل كلمة مرور التحقق بخطوتين (اتركها فاضية لو مش مفعّلة):",
                        "كلمة مرور تليجرام");
                case "session_pathname":
                    return Path.Combine(Application.StartupPath, "telegram.session");
                default:
                    return null;
            }
        }

        /// <summary>
        /// نافذة إدخال نص بسيطة (بديل عن Microsoft.VisualBasic.Interaction.InputBox
        /// عشان نتجنب مشاكل الـ assembly reference). تستخدم WinForms عادي بس.
        /// </summary>
        private string ShowInputBox(string prompt, string title)
        {
            using (var form = new Form())
            using (var lbl = new Label())
            using (var txt = new TextBox())
            using (var btnOk = new Button())
            {
                form.Text = title;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ClientSize = new System.Drawing.Size(380, 120);
                form.RightToLeft = RightToLeft.Yes;
                form.RightToLeftLayout = true;
                form.TopMost = true;

                lbl.Text = prompt;
                lbl.SetBounds(12, 12, 356, 40);
                lbl.AutoSize = false;

                txt.SetBounds(12, 55, 356, 23);

                btnOk.Text = "موافق";
                btnOk.DialogResult = DialogResult.OK;
                btnOk.SetBounds(272, 88, 96, 26);

                form.Controls.Add(lbl);
                form.Controls.Add(txt);
                form.Controls.Add(btnOk);
                form.AcceptButton = btnOk;

                return form.ShowDialog() == DialogResult.OK ? txt.Text : string.Empty;
            }
        }

        private async Task EnsureConnectedAsync()
        {
            if (_client != null && _channelPeer != null)
                return;

            _client = new Client(ConfigCallback);
            await _client.LoginUserIfNeeded();

            var resolved = await _client.Contacts_ResolveUsername(ChannelUsername);
            var channel = resolved.chats?.Values.OfType<Channel>().FirstOrDefault();

            if (channel == null)
                throw new InvalidOperationException(
                    "تعذر العثور على القناة. تأكد إن ChannelUsername مظبوط صح.");

            _channelPeer = new InputPeerChannel(channel.id, channel.access_hash);
        }

        /// <summary>
        /// يجيب آخر رسالة في القناة فيها سعر عيار 21 ويحللها.
        /// </summary>
        public async Task<GoldPriceUpdate> GetLatestPriceAsync()
        {
            await EnsureConnectedAsync();

            // بنجيب آخر 20 رسالة ونفحصهم من الأحدث للأقدم لحد ما نلاقي رسالة فيها سعر صحيح
            var history = await _client.Messages_GetHistory(_channelPeer, limit: 20);

            foreach (var msgBase in history.Messages)
            {
                if (msgBase is Message msg && !string.IsNullOrWhiteSpace(msg.message))
                {
                    var parsed = ParseMessage(msg.message, msg.Date);
                    if (parsed != null)
                        return parsed;
                }
            }

            return null;
        }

        /// <summary>
        /// يحلل نص رسالة القناة ويطلع منها سعر الشراء والبيع لعيار 21.
        /// بيتعامل مع الشكلين اللي القناة بتنشرهم بيهم (بتسمية شراء/بيع، أو رقمين بس تحت بعض).
        /// </summary>
        private GoldPriceUpdate ParseMessage(string text, DateTime date)
        {
            // بنلاقي مكان ذكر "عيار 21" في النص (بالأرقام العربي أو الهندي)
            var karatMatch = Regex.Match(text, @"عيار\s*(?:21|٢١)");
            if (!karatMatch.Success)
                return null;

            string tail = text.Substring(karatMatch.Index);

            decimal buy, sell;

            var buyMatch = Regex.Match(tail, @"شراء[:\s]*([\d,]+(?:\.\d+)?)");
            var sellMatch = Regex.Match(tail, @"بيع[:\s]*([\d,]+(?:\.\d+)?)");

            if (buyMatch.Success && sellMatch.Success)
            {
                buy = ParseDecimal(buyMatch.Groups[1].Value);
                sell = ParseDecimal(sellMatch.Groups[1].Value);
            }
            else
            {
                // فورمات بديل: رقمين لوحدهم بعد سطر "عيار 21" مباشرة (شراء ثم بيع)
                var numbers = Regex.Matches(tail, @"\d{3,5}(?:\.\d+)?")
                    .Cast<Match>()
                    .Select(m => ParseDecimal(m.Value))
                    .Where(v => v > 1000 && v < 20000) // فلترة أي رقم مش منطقي كسعر جرام
                    .Take(2)
                    .ToList();

                if (numbers.Count < 2)
                    return null;

                buy = numbers[0];
                sell = numbers[1];
            }

            return new GoldPriceUpdate
            {
                Buy21 = buy,
                Sell21 = sell,
                MessageDateUtc = date,
                RawText = text
            };
        }

        private decimal ParseDecimal(string s)
        {
            s = s.Replace(",", "");
            return decimal.Parse(s, CultureInfo.InvariantCulture);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}