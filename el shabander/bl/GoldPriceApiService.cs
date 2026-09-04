using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace el_shabander.bl
{
    /// <summary>
    /// شكل الرد اللي بيرجع من الـ API الخاص بأسعار الذهب.
    /// GET https://goldpriceserver.runasp.net/api/goldprice
    /// </summary>
    public class GoldPriceApiResult
    {
        [JsonPropertyName("buy24")]
        public decimal Buy24 { get; set; }

        [JsonPropertyName("sell24")]
        public decimal Sell24 { get; set; }

        [JsonPropertyName("buy22")]
        public decimal Buy22 { get; set; }

        [JsonPropertyName("sell22")]
        public decimal Sell22 { get; set; }

        [JsonPropertyName("buy21")]
        public decimal Buy21 { get; set; }

        [JsonPropertyName("sell21")]
        public decimal Sell21 { get; set; }

        [JsonPropertyName("buy18")]
        public decimal Buy18 { get; set; }

        [JsonPropertyName("sell18")]
        public decimal Sell18 { get; set; }

        [JsonPropertyName("buy14")]
        public decimal Buy14 { get; set; }

        [JsonPropertyName("sell14")]
        public decimal Sell14 { get; set; }

        [JsonPropertyName("updatedAtUtc")]
        public DateTime UpdatedAtUtc { get; set; }
    }

    /// <summary>
    /// خدمة بسيطة لجلب سعر الذهب الحالي (بيع/شراء لكل عيار) من الـ API الخاص بالمشروع.
    ///
    /// الاستخدام:
    ///   var result = await GoldPriceApiService.GetGoldPriceAsync();
    ///   lblBuy21.Text  = result.Buy21.ToString("N2");
    ///   lblSell21.Text = result.Sell21.ToString("N2");
    /// </summary>
    public static class GoldPriceApiService
    {
        private const string ApiUrl = "https://goldpriceserver.runasp.net/api/goldprice";

        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        /// <summary>
        /// يجيب أسعار الذهب الحالية (كل العيارات) من الـ API.
        /// بيرمي Exception لو حصل خطأ في الاتصال أو في قراءة الرد؛ المستدعي مسؤول عن معالجتها.
        /// </summary>
        public static async Task<GoldPriceApiResult> GetGoldPriceAsync()
        {
            var json = await _http.GetStringAsync(ApiUrl).ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<GoldPriceApiResult>(json, options);
            if (result == null)
            {
                throw new InvalidOperationException("تعذر قراءة رد الـ API الخاص بسعر الذهب.");
            }

            return result;
        }
    }
}
