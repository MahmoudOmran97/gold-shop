using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using el_shabander.bl;

namespace el_shabander.pl
{
    /// <summary>
    /// كنترول يعرض سعر بيع وشراء الذهب، ويحدث نفسه تلقائيًا كل دقيقة.
    /// له وضعان:
    ///   - Compact = true  : شريط صغير (عيار 21 بس) يوضع أعلى شاشة الداشبورد (TileControl).
    ///   - Compact = false : شاشة كاملة تعرض كل الأعيرة (24 / 22 / 21 / 18 / 14).
    /// استدعِ SetCompactMode(true/false) قبل إضافة الكنترول للحاوية المطلوبة.
    /// </summary>
    public partial class ucGoldPrice : UserControl
    {
        private static readonly (string Karat, string Label)[] Karats = new[]
        {
            ("24", "عيار 24"),
            ("22", "عيار 22"),
            ("21", "عيار 21"),
            ("18", "عيار 18"),
            ("14", "عيار 14"),
        };

        private System.Windows.Forms.Timer refreshTimer;
        private bool isCompact;

        // الوضع المصغّر (عيار 21 بس)
        private Label lblCompactBuy;
        private Label lblCompactSell;

        // الوضع الكامل (كل الأعيرة)
        private readonly Dictionary<string, Label> buyLabels = new Dictionary<string, Label>();
        private readonly Dictionary<string, Label> sellLabels = new Dictionary<string, Label>();

        private Label lblUpdatedAt;
        private Label lblStatus;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;

        public ucGoldPrice()
        {
            InitializeComponent();

            refreshTimer = new System.Windows.Forms.Timer { Interval = 60000 }; // تحديث تلقائي كل دقيقة
            refreshTimer.Tick += async (s, e) => await LoadGoldPriceAsync();
            refreshTimer.Start();
            this.Disposed += (s, e) => refreshTimer?.Stop();

            SetCompactMode(false);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ucGoldPrice
            // 
            this.Name = "ucGoldPrice";
            this.Size = new System.Drawing.Size(1030, 130);
            this.ResumeLayout(false);
        }

        /// <summary>
        /// يبدّل شكل الكنترول بين الشريط المصغّر (فوق الداشبورد) والشاشة الكاملة بكل الأعيرة.
        /// </summary>
        public void SetCompactMode(bool compact)
        {
            isCompact = compact;

            this.Controls.Clear();
            buyLabels.Clear();
            sellLabels.Clear();
            this.RightToLeft = RightToLeft.Yes;

            if (isCompact)
                BuildCompactLayout();
            else
                BuildFullLayout();

            _ = LoadGoldPriceAsync();
        }

        // ===================== الوضع المصغّر (شريط أعلى الداشبورد - عيار 21) =====================
        private void BuildCompactLayout()
        {
            this.Dock = DockStyle.Top;
            this.Height = 90;
            this.BackColor = Color.FromArgb(255, 248, 225);

            var lblTitle = new Label
            {
                Text = "سعر الذهب عيار 21",
                Font = new Font("Cairo", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(120, 90, 10),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Right,
                Width = 230
            };

            lblCompactSell = new Label
            {
                Text = "بيع: --",
                Font = new Font("Cairo", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(198, 40, 40),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Right,
                Width = 220
            };

            lblCompactBuy = new Label
            {
                Text = "شراء: --",
                Font = new Font("Cairo", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 125, 50),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Right,
                Width = 220
            };

            btnRefresh = new DevExpress.XtraEditors.SimpleButton
            {
                Text = "تحديث",
                Font = new Font("Cairo", 10F, FontStyle.Bold),
                Width = 100,
                Height = 34
            };
            btnRefresh.Click += async (s, e) => await LoadGoldPriceAsync();

            var pnlRefreshHolder = new Panel { Dock = DockStyle.Left, Width = 120 };
            btnRefresh.Location = new Point(10, 28);
            pnlRefreshHolder.Controls.Add(btnRefresh);

            lblUpdatedAt = new Label
            {
                Text = "",
                Font = new Font("Cairo", 9F, FontStyle.Regular),
                ForeColor = Color.Gray,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Height = 20
            };

            lblStatus = new Label
            {
                Text = "",
                Font = new Font("Cairo", 10F, FontStyle.Regular),
                ForeColor = Color.Red,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Visible = false
            };

            this.Controls.Add(lblStatus);
            this.Controls.Add(lblCompactBuy);
            this.Controls.Add(lblCompactSell);
            this.Controls.Add(pnlRefreshHolder);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUpdatedAt);
        }

        // ===================== الوضع الكامل (شاشة مستقلة - كل الأعيرة) =====================
        private void BuildFullLayout()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            var lblTitle = new Label
            {
                Text = "أسعار الذهب",
                Font = new Font("Cairo", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };

            lblUpdatedAt = new Label
            {
                Text = "",
                Font = new Font("Cairo", 11F, FontStyle.Regular),
                ForeColor = Color.Gray,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 28
            };

            lblStatus = new Label
            {
                Text = "جاري تحميل السعر...",
                Font = new Font("Cairo", 12F, FontStyle.Regular),
                ForeColor = Color.DarkOrange,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 32
            };

            btnRefresh = new DevExpress.XtraEditors.SimpleButton
            {
                Text = "تحديث السعر",
                Font = new Font("Cairo", 11F, FontStyle.Bold),
                Width = 180,
                Height = 40
            };
            btnRefresh.Click += async (s, e) => await LoadGoldPriceAsync();

            var pnlButtonHolder = new Panel { Dock = DockStyle.Top, Height = 55 };
            btnRefresh.Location = new Point((this.Width - btnRefresh.Width) / 2, 5);
            btnRefresh.Anchor = AnchorStyles.None;
            pnlButtonHolder.Controls.Add(btnRefresh);
            pnlButtonHolder.Resize += (s, e) =>
            {
                btnRefresh.Location = new Point((pnlButtonHolder.Width - btnRefresh.Width) / 2, 8);
            };

            // حاوية الجدول: بتاخد المساحة المتبقية كلها وتسمح بالتمرير بدل ما الجدول يتقص لو المساحة صغيرت
            var pnlTableWrapper = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(50, 10, 50, 20)
            };

            // جدول الأعيرة: عنوان + 5 صفوف (24 / 22 / 21 / 18 / 14)
            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 45 + (Karats.Length * 65),
                ColumnCount = 3,
                RowCount = Karats.Length + 1,
                BorderStyle = BorderStyle.FixedSingle,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            for (int i = 0; i < Karats.Length; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));

            table.Controls.Add(HeaderCell("العيار"), 0, 0);
            table.Controls.Add(HeaderCell("سعر البيع"), 1, 0);
            table.Controls.Add(HeaderCell("سعر الشراء"), 2, 0);

            for (int i = 0; i < Karats.Length; i++)
            {
                var (karat, label) = Karats[i];
                bool isMain = karat == "21";
                int row = i + 1;

                var karatLabel = new Label
                {
                    Text = label,
                    Font = new Font("Cairo", isMain ? 15F : 13F, FontStyle.Bold),
                    ForeColor = isMain ? Color.FromArgb(120, 90, 10) : Color.FromArgb(64, 64, 64),
                    BackColor = isMain ? Color.FromArgb(255, 248, 225) : Color.White,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                var sellLabel = new Label
                {
                    Text = "--",
                    Font = new Font("Cairo", isMain ? 16F : 14F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(198, 40, 40),
                    BackColor = isMain ? Color.FromArgb(255, 248, 225) : Color.White,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                var buyLabel = new Label
                {
                    Text = "--",
                    Font = new Font("Cairo", isMain ? 16F : 14F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(46, 125, 50),
                    BackColor = isMain ? Color.FromArgb(255, 248, 225) : Color.White,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                table.Controls.Add(karatLabel, 0, row);
                table.Controls.Add(sellLabel, 1, row);
                table.Controls.Add(buyLabel, 2, row);

                sellLabels[karat] = sellLabel;
                buyLabels[karat] = buyLabel;
            }

            pnlTableWrapper.Controls.Add(table);

            this.Controls.Add(pnlTableWrapper);
            this.Controls.Add(pnlButtonHolder);
            this.Controls.Add(lblStatus);
            this.Controls.Add(lblUpdatedAt);
            this.Controls.Add(lblTitle);
        }

        private Label HeaderCell(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Cairo", 13F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(96, 76, 20),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private async Task LoadGoldPriceAsync()
        {
            try
            {
                if (btnRefresh != null) btnRefresh.Enabled = false;
                if (lblStatus != null)
                {
                    lblStatus.Text = isCompact ? "" : "جاري تحميل السعر...";
                    lblStatus.ForeColor = Color.DarkOrange;
                    lblStatus.Visible = !isCompact;
                }

                var price = await GoldPriceApiService.GetGoldPriceAsync();

                if (isCompact)
                {
                    lblCompactBuy.Text = "شراء: " + price.Buy21.ToString("N0") + " جنيه";
                    lblCompactSell.Text = "بيع: " + price.Sell21.ToString("N0") + " جنيه";
                }
                else
                {
                    SetKaratRow("24", price.Buy24, price.Sell24);
                    SetKaratRow("22", price.Buy22, price.Sell22);
                    SetKaratRow("21", price.Buy21, price.Sell21);
                    SetKaratRow("18", price.Buy18, price.Sell18);
                    SetKaratRow("14", price.Buy14, price.Sell14);
                }

                // 12 ساعة مع AM/PM
                var localTime = price.UpdatedAtUtc.ToLocalTime();
                lblUpdatedAt.Text = "آخر تحديث: " + localTime.ToString("yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture);

                if (lblStatus != null) lblStatus.Visible = false;
            }
            catch (Exception)
            {
                if (lblStatus != null)
                {
                    lblStatus.Text = "تعذر تحميل سعر الذهب، تأكد من الاتصال بالإنترنت";
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Visible = true;
                }
            }
            finally
            {
                if (btnRefresh != null) btnRefresh.Enabled = true;
            }
        }

        private void SetKaratRow(string karat, decimal buy, decimal sell)
        {
            if (buyLabels.TryGetValue(karat, out var buyLabel))
                buyLabel.Text = buy.ToString("N0") + " جنيه";

            if (sellLabels.TryGetValue(karat, out var sellLabel))
                sellLabel.Text = sell.ToString("N0") + " جنيه";
        }
    }
}
