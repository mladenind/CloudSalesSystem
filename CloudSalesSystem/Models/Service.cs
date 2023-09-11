using System.ComponentModel.DataAnnotations;

namespace CloudSalesSystem.Models
{
    public class Service
    {
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        public int? MaxQuantity { get; set; }

        [MaxLength(50)]
        public string Id { get; set; } = string.Empty;
    }
}
