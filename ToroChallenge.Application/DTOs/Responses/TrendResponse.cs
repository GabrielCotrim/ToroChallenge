using System.Text.Json.Serialization;

namespace ToroChallenge.Application.DTOs.Responses
{
    public class TrendResponse
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("currentPrice")]
        public double CurrentPrice { get; set; }
    }
}
