namespace CloudSalesSystem.Models.DTOs
{
    public class AccountLicenseDto
    {
        public string LicenseId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
