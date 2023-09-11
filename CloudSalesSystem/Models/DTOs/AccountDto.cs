using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CloudSalesSystem.Models.DTOs
{
    public class AccountDto
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
    }
}
