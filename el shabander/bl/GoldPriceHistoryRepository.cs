using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace el_shabander.bl
{
    /// <summary>
    /// لقطة سعر ذهب واحدة محفوظة في تاريخ الأسعار (كل الأعيرة في لحظة زمنية معيّنة).
    /// </summary>
    public class GoldPriceHistoryPoint
    {
        public DateTime CapturedAtUtc { get; set; }
        public decimal Buy24 { get; set; }
        public decimal Sell24 { get; set; }
        public decimal Buy22 { get; set; }
        public decimal Sell22 { get; set; }
        public decimal Buy21 { get; set; }
        public decimal Sell21 { get; set; }
        public decimal Buy18 { get; set; }
        public decimal Sell18 { get; set; }
        public decimal Buy14 { get; set; }
        public decimal Sell14 { get; set; }

        /// <summary>
        /// بيرجع سعر عيار معيّن (بيع/شراء) من اللقطة دي، عشان شاشة الشارت تقدر تشتغل بأي عيار
        /// من غير ما تحتاج سويتش طويل في كل مكان.
        /// </summary>
        public decimal GetPrice(string karat, bool sell)
        {
            switch (karat)
            {
                case "24": return sell ? Sell24 : Buy24;
                case "22": return sell ? Sell22 : Buy22;
                case "21": return sell ? Sell21 : Buy21;
                case "18": return sell ? Sell18 : Buy18;
                case "14": return sell ? Sell14 : Buy14;
                default: return sell ? Sell21 : Buy21;
            }
        }
    }

    /// <summary>
    /// تخزين واسترجاع سجل تاريخي لأسعار الذهب في جدول TB_GoldPriceHistory.
    ///
    /// بيستخدم ADO.NET عادي (SqlConnection/SqlCommand) على نفس قاعدة البيانات المعرّفة في
    /// connectionStrings باسم "gold_shopEntities" (بيستخرج منها نص اتصال SqlClient العادي)،
    /// من غير ما يلمس موديل الـ Entity Framework (Model1.edmx) خالص. الجدول بيتعمل تلقائيًا
    /// أول مرة (CREATE TABLE IF NOT EXISTS)، فمش محتاج تعمل حاجة يدوي في قاعدة البيانات.
    ///
    /// الاستخدام:
    ///   await GoldPriceHistoryRepository.SaveSnapshotAsync(price);            // بعد كل تحديث سعر
    ///   var points = await GoldPriceHistoryRepository.GetHistoryAsync(from);  // لعرضها في الشارت
    /// </summary>
    public static class GoldPriceHistoryRepository
    {
        private static bool _tableEnsured;
        private static readonly object _ensureLock = new object();

        private static string GetSqlConnectionString()
        {
            var efConnectionString = ConfigurationManager.ConnectionStrings["gold_shopEntities"].ConnectionString;
            var builder = new EntityConnectionStringBuilder(efConnectionString);
            return builder.ProviderConnectionString;
        }

        /// <summary>
        /// بينشئ جدول تاريخ الأسعار لو لسه مش موجود. آمن يتنادى أكتر من مرة.
        /// </summary>
        private static async Task EnsureTableExistsAsync()
        {
            if (_tableEnsured) return;

            const string sql = @"
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'TB_GoldPriceHistory')
BEGIN
    CREATE TABLE TB_GoldPriceHistory
    (
        id INT IDENTITY(1,1) PRIMARY KEY,
        captured_at_utc DATETIME NOT NULL,
        buy24 DECIMAL(18,2) NOT NULL,
        sell24 DECIMAL(18,2) NOT NULL,
        buy22 DECIMAL(18,2) NOT NULL,
        sell22 DECIMAL(18,2) NOT NULL,
        buy21 DECIMAL(18,2) NOT NULL,
        sell21 DECIMAL(18,2) NOT NULL,
        buy18 DECIMAL(18,2) NOT NULL,
        sell18 DECIMAL(18,2) NOT NULL,
        buy14 DECIMAL(18,2) NOT NULL,
        sell14 DECIMAL(18,2) NOT NULL
    );
    CREATE INDEX IX_TB_GoldPriceHistory_captured_at_utc ON TB_GoldPriceHistory(captured_at_utc);
END";

            using (var conn = new SqlConnection(GetSqlConnectionString()))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(sql, conn))
                {
                    await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }

            lock (_ensureLock)
            {
                _tableEnsured = true;
            }
        }

        /// <summary>
        /// بيسجّل لقطة سعر جديدة (كل الأعيرة) بتوقيت الـ API (أو UTC الحالي لو مش متوفر).
        /// بترمي Exception لو فشل الحفظ؛ المستدعي مسؤول عن معالجتها (متسبّبش في وقف تحديث الشاشة).
        /// </summary>
        public static async Task SaveSnapshotAsync(GoldPriceApiResult price)
        {
            await EnsureTableExistsAsync().ConfigureAwait(false);

            const string sql = @"
INSERT INTO TB_GoldPriceHistory
    (captured_at_utc, buy24, sell24, buy22, sell22, buy21, sell21, buy18, sell18, buy14, sell14)
VALUES
    (@capturedAtUtc, @buy24, @sell24, @buy22, @sell22, @buy21, @sell21, @buy18, @sell18, @buy14, @sell14)";

            using (var conn = new SqlConnection(GetSqlConnectionString()))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(sql, conn))
                {
                    var capturedAtUtc = price.UpdatedAtUtc == default(DateTime) ? DateTime.UtcNow : price.UpdatedAtUtc;

                    cmd.Parameters.AddWithValue("@capturedAtUtc", capturedAtUtc);
                    cmd.Parameters.AddWithValue("@buy24", price.Buy24);
                    cmd.Parameters.AddWithValue("@sell24", price.Sell24);
                    cmd.Parameters.AddWithValue("@buy22", price.Buy22);
                    cmd.Parameters.AddWithValue("@sell22", price.Sell22);
                    cmd.Parameters.AddWithValue("@buy21", price.Buy21);
                    cmd.Parameters.AddWithValue("@sell21", price.Sell21);
                    cmd.Parameters.AddWithValue("@buy18", price.Buy18);
                    cmd.Parameters.AddWithValue("@sell18", price.Sell18);
                    cmd.Parameters.AddWithValue("@buy14", price.Buy14);
                    cmd.Parameters.AddWithValue("@sell14", price.Sell14);

                    await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// بيرجع كل نقاط السعر المسجّلة من تاريخ معيّن (UTC) لحد دلوقتي، مرتبة تصاعديًا بالتاريخ.
        /// مرر null في fromUtc عشان تجيب كل المدة المتاحة من غير أي فلترة (وضع "الكل").
        /// </summary>
        public static async Task<List<GoldPriceHistoryPoint>> GetHistoryAsync(DateTime? fromUtc)
        {
            await EnsureTableExistsAsync().ConfigureAwait(false);

            var sql = "SELECT captured_at_utc, buy24, sell24, buy22, sell22, buy21, sell21, buy18, sell18, buy14, sell14 " +
                       "FROM TB_GoldPriceHistory ";
            if (fromUtc.HasValue)
                sql += "WHERE captured_at_utc >= @fromUtc ";
            sql += "ORDER BY captured_at_utc ASC";

            var result = new List<GoldPriceHistoryPoint>();

            using (var conn = new SqlConnection(GetSqlConnectionString()))
            {
                await conn.OpenAsync().ConfigureAwait(false);
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (fromUtc.HasValue)
                        cmd.Parameters.AddWithValue("@fromUtc", fromUtc.Value);

                    using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                    {
                        while (await reader.ReadAsync().ConfigureAwait(false))
                        {
                            result.Add(new GoldPriceHistoryPoint
                            {
                                CapturedAtUtc = reader.GetDateTime(0),
                                Buy24 = reader.GetDecimal(1),
                                Sell24 = reader.GetDecimal(2),
                                Buy22 = reader.GetDecimal(3),
                                Sell22 = reader.GetDecimal(4),
                                Buy21 = reader.GetDecimal(5),
                                Sell21 = reader.GetDecimal(6),
                                Buy18 = reader.GetDecimal(7),
                                Sell18 = reader.GetDecimal(8),
                                Buy14 = reader.GetDecimal(9),
                                Sell14 = reader.GetDecimal(10)
                            });
                        }
                    }
                }
            }

            return result;
        }
    }
}
