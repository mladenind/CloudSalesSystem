using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CloudSalesSystem.Models.DTOs
{
    public class AccountLicenseDto
    {
        [JsonPropertyName("LicenseId")]
        [MaxLength(50)]
        public string LicenseId { get; set; } = string.Empty;

        [JsonPropertyName("Name")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("ExpirationDate")]
        public DateOnly? ExpirationDate { get; set; }
    }
}
