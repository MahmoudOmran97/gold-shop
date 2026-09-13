using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace el_shabander.bl
{
    /// <summary>
    /// نتيجة فحص حالة الاشتراك الحالي.
    /// </summary>
    public class SubscriptionStatus
    {
        /// <summary>هل يوجد سجل اشتراك تم تفعيله من قبل على هذا الجهاز؟</summary>
        public bool HasSubscriptionRecord { get; set; }

        /// <summary>هل الاشتراك سارٍ الآن؟</summary>
        public bool IsActive { get; set; }

        /// <summary>تاريخ انتهاء الاشتراك (إن وجد).</summary>
        public DateTime? EndDate { get; set; }

        /// <summary>عدد الأيام المتبقية (صفر إذا كان منتهيًا).</summary>
        public int RemainingDays { get; set; }

        /// <summary>هل تم اكتشاف محاولة تلاعب في تاريخ/ساعة الجهاز؟</summary>
        public bool TamperDetected { get; set; }
    }

    /// <summary>
    /// نظام الاشتراك (subscription) الخاص بالبرنامج.
    /// يعتمد نفس فكرة التشفير الموجودة أصلاً في المشروع (XOR + Base64)
    /// لكن كود التفعيل هنا يحمل داخل نفسه: (الرقم التسلسلي للجهاز + عدد أيام الاشتراك).
    ///
    /// عند إدخال كود تفعيل صحيح يتم تخزين تاريخ انتهاء الاشتراك في جدول
    /// "tb_subscription" داخل قاعدة بيانات البرنامج نفسها (وليس فقط في
    /// إعدادات المستخدم المحلية)، حتى لا يسهل تصفير الاشتراك بحذف الإعدادات
    /// أو بإعادة تثبيت البرنامج على نفس القاعدة.
    ///
    /// ملاحظة أمان: هذا أسلوب حماية عملي مناسب لبرنامج محلي صغير (نفس مستوى
    /// الحماية المستخدم أصلاً في المشروع)، وليس حماية صناعية قوية 100%، لأن
    /// أي شخص يملك أدوات فك الترجمة (decompiler) يمكنه نظريًا الوصول لطريقة
    /// التشفير. لحماية أقوى يُفضّل مستقبلاً استخدام خدمة ترخيص أونلاين حقيقية.
    /// </summary>
    public static class SubscriptionManager
    {
        // *** هام جدًا ***
        // هذا المفتاح السري يجب أن يكون متطابقًا تمامًا بين:
        //   1) هذا الملف (داخل برنامج العميل).
        //   2) أداة توليد أكواد التفعيل (SubscriptionCodeGenerator) التي يحتفظ بها المطوّر فقط.
        // لا يجب إرسال أداة التوليد أو هذا المفتاح لأي عميل.
        private const string SecretKey = "GoldShop$ubKey_2026_ElShabander#Omran";

        private const int ClockSkewToleranceMinutes = 5;

        #region تشفير / فك تشفير (نفس أسلوب XOR المستخدم أصلاً في المشروع)

        private static string XorEncryptToBase64(string plainText, string key)
        {
            byte[] data = Encoding.UTF8.GetBytes(plainText);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= keyBytes[i % keyBytes.Length];
            }
            return Convert.ToBase64String(data);
        }

        private static string XorDecryptFromBase64(string base64CipherText, string key)
        {
            byte[] data = Convert.FromBase64String(base64CipherText);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= keyBytes[i % keyBytes.Length];
            }
            return Encoding.UTF8.GetString(data);
        }

        /// <summary>
        /// توليد كود تفعيل لعدد أيام معيّن مرتبط برقم تسلسلي معيّن.
        /// (يُستخدم من داخل أداة المطوّر SubscriptionCodeGenerator).
        /// </summary>
        public static string GenerateActivationCode(string machineSerial, int days)
        {
            if (string.IsNullOrWhiteSpace(machineSerial))
                throw new ArgumentException("الرقم التسلسلي مطلوب.", nameof(machineSerial));
            if (days <= 0)
                throw new ArgumentException("عدد الأيام يجب أن يكون أكبر من صفر.", nameof(days));

            // إضافة بصمة وقت التوليد فقط لجعل كل كود مختلف شكليًا عن غيره.
            string payload = $"{machineSerial}|{days}|{DateTime.UtcNow.Ticks}";
            return XorEncryptToBase64(payload, SecretKey);
        }

        #endregion

        #region الاتصال بقاعدة البيانات وإنشاء الجدول

        private static SqlConnection GetConnection()
        {
            // سلسلة اتصال ADO.NET عادية (نفس بيانات قاعدة بيانات البرنامج) مضافة في App.config
            string connectionString = ConfigurationManager.ConnectionStrings["gold_shopSqlConnection"].ConnectionString;
            return new SqlConnection(connectionString);
        }

        private static void EnsureTable(SqlConnection conn)
        {
            const string sql = @"
IF OBJECT_ID('dbo.tb_subscription', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.tb_subscription
    (
        id                     INT           NOT NULL PRIMARY KEY,
        machine_serial         NVARCHAR(200) NULL,
        start_date             DATETIME      NOT NULL,
        end_date               DATETIME      NOT NULL,
        last_checked           DATETIME      NOT NULL,
        last_activation_code   NVARCHAR(400) NULL
    )
END";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        /// <summary>
        /// قراءة حالة الاشتراك الحالية (نشط / منتهي / لا يوجد اشتراك بعد).
        /// يقوم أيضًا بتحديث "آخر وقت تم فيه الفحص" لاكتشاف محاولات تعديل تاريخ الجهاز للخلف.
        /// </summary>
        public static SubscriptionStatus GetStatus()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                EnsureTable(conn);

                DateTime? endDate = null;
                DateTime? lastChecked = null;

                using (var cmd = new SqlCommand("SELECT end_date, last_checked FROM dbo.tb_subscription WHERE id = 1", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        endDate = (DateTime)reader["end_date"];
                        lastChecked = (DateTime)reader["last_checked"];
                    }
                }

                if (endDate == null)
                {
                    return new SubscriptionStatus
                    {
                        HasSubscriptionRecord = false,
                        IsActive = false,
                        RemainingDays = 0
                    };
                }

                DateTime now = DateTime.Now;
                bool tamper = lastChecked.HasValue && now < lastChecked.Value.AddMinutes(-ClockSkewToleranceMinutes);

                // لا نُرجع "آخر وقت فحص" للخلف أبدًا حتى لو تم اكتشاف تلاعب.
                DateTime newLastChecked = (lastChecked.HasValue && lastChecked.Value > now) ? lastChecked.Value : now;
                using (var cmd = new SqlCommand("UPDATE dbo.tb_subscription SET last_checked = @lc WHERE id = 1", conn))
                {
                    cmd.Parameters.AddWithValue("@lc", newLastChecked);
                    cmd.ExecuteNonQuery();
                }

                if (tamper)
                {
                    return new SubscriptionStatus
                    {
                        HasSubscriptionRecord = true,
                        IsActive = false,
                        EndDate = endDate,
                        RemainingDays = 0,
                        TamperDetected = true
                    };
                }

                bool active = now <= endDate.Value;
                int remaining = active ? (int)Math.Ceiling((endDate.Value - now).TotalHours / 24.0) : 0;

                return new SubscriptionStatus
                {
                    HasSubscriptionRecord = true,
                    IsActive = active,
                    EndDate = endDate,
                    RemainingDays = remaining,
                    TamperDetected = false
                };
            }
        }

        /// <summary>
        /// محاولة تفعيل / تجديد الاشتراك باستخدام كود تفعيل.
        /// - إذا كان هناك اشتراك سارٍ بالفعل، تُضاف الأيام الجديدة فوق تاريخ الانتهاء الحالي (تجديد).
        /// - إذا لم يوجد اشتراك سارٍ، يبدأ الاشتراك من الآن.
        /// </summary>
        public static bool TryActivate(string activationCode, out string message)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(activationCode))
                {
                    message = "من فضلك أدخل كود التفعيل.";
                    return false;
                }

                string trimmedCode = activationCode.Trim();

                string currentSerial = el_shabander.main.GetSerialNumber();
                if (string.IsNullOrWhiteSpace(currentSerial))
                {
                    message = "تعذر قراءة الرقم التسلسلي لهذا الجهاز، برجاء المحاولة مرة أخرى.";
                    return false;
                }

                string decoded;
                try
                {
                    decoded = XorDecryptFromBase64(trimmedCode, SecretKey);
                }
                catch
                {
                    message = "كود التفعيل غير صحيح.";
                    return false;
                }

                string[] parts = decoded.Split('|');
                if (parts.Length < 2 || !int.TryParse(parts[1], out int days) || days <= 0)
                {
                    message = "كود التفعيل غير صحيح.";
                    return false;
                }

                string codeSerial = parts[0];
                if (!string.Equals(codeSerial, currentSerial, StringComparison.OrdinalIgnoreCase))
                {
                    message = "كود التفعيل هذا غير مخصص لهذا الجهاز.";
                    return false;
                }

                using (var conn = GetConnection())
                {
                    conn.Open();
                    EnsureTable(conn);

                    DateTime? currentEnd = null;
                    string lastUsedCode = null;

                    using (var cmd = new SqlCommand("SELECT end_date, last_activation_code FROM dbo.tb_subscription WHERE id = 1", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            currentEnd = reader["end_date"] as DateTime?;
                            lastUsedCode = reader["last_activation_code"] as string;
                        }
                    }

                    if (!string.IsNullOrEmpty(lastUsedCode) &&
                        string.Equals(lastUsedCode, trimmedCode, StringComparison.Ordinal))
                    {
                        message = "تم استخدام هذا الكود من قبل.";
                        return false;
                    }

                    DateTime now = DateTime.Now;
                    DateTime baseDate = (currentEnd.HasValue && currentEnd.Value > now) ? currentEnd.Value : now;
                    DateTime newEnd = baseDate.AddDays(days);

                    if (currentEnd.HasValue)
                    {
                        using (var cmd = new SqlCommand(
                            @"UPDATE dbo.tb_subscription
                              SET end_date = @e, last_checked = @n, last_activation_code = @c, machine_serial = @s
                              WHERE id = 1", conn))
                        {
                            cmd.Parameters.AddWithValue("@e", newEnd);
                            cmd.Parameters.AddWithValue("@n", now);
                            cmd.Parameters.AddWithValue("@c", trimmedCode);
                            cmd.Parameters.AddWithValue("@s", currentSerial);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (var cmd = new SqlCommand(
                            @"INSERT INTO dbo.tb_subscription (id, machine_serial, start_date, end_date, last_checked, last_activation_code)
                              VALUES (1, @s, @st, @e, @n, @c)", conn))
                        {
                            cmd.Parameters.AddWithValue("@s", currentSerial);
                            cmd.Parameters.AddWithValue("@st", now);
                            cmd.Parameters.AddWithValue("@e", newEnd);
                            cmd.Parameters.AddWithValue("@n", now);
                            cmd.Parameters.AddWithValue("@c", trimmedCode);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    message = $"تم تفعيل الاشتراك بنجاح، وسيستمر العمل حتى تاريخ {newEnd:yyyy-MM-dd}.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = "حدث خطأ أثناء التفعيل: " + ex.Message;
                return false;
            }
        }
    }
}
