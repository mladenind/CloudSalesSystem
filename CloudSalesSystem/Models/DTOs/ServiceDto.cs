using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CloudSalesSystem.Models.DTOs
{
    public class ServiceDto
    {
        [JsonPropertyName("Name")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("Description")]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("Id")]
        [MaxLength(50)]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("MaxQuantity")]
        public int? MaxQuantity { get; set; }
    }
}
