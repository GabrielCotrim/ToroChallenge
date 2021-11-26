using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToroChallenge.Application.DTOs.Requests
{
    public class OrderRequest
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("amount"), Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que 0")]
        public int Amount { get; set; }
    }
}
