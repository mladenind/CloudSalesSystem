using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CloudSalesSystem.Models.DTOs
{
    public class MoneyDto
    {
        [JsonPropertyName("Currency")]
        [MaxLength(50)]
        public string Currency { get; set; } = string.Empty;

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }
    }
}
