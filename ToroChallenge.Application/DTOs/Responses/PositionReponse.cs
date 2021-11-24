using System.Text.Json.Serialization;

namespace ToroChallenge.Application.DTOs.Responses
{
    public class PositionReponse : TrendResponse
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
    }
}
