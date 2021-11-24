using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ToroChallenge.Application.DTOs.Responses
{
    public class UserPositionResponse
    {
        [JsonPropertyName("checkingAccountAmount")]
        public double CheckingAccountAmount { get; set; }

        [JsonPropertyName("positions")]
        public List<PositionReponse> Positions { get; set; } = new List<PositionReponse>();

        [JsonPropertyName("consolidated")]
        public double Consolidated { get; set; }
    }
}
