namespace CloudSalesSystem.Models.DTOs
{
    public class ServiceDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public int? MaxQuantity { get; set; }
    }
}
