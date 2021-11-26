using System.Text.Json.Serialization;

namespace ToroChallenge.Application.DTOs.Responses
{
    public class PositionReponse
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("currentPrice")]
        public double CurrentPrice { get; set; }
    }
}
