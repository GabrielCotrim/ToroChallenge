using System.Text.Json.Serialization;

namespace ToroChallenge.Application.DTOs.Requests
{
    public class OrderRequest
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }
    }
}
