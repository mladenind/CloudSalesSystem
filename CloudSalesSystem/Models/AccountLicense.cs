using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CloudSalesSystem.Models
{
    [Index(nameof(AccountId), nameof(LicenseId), nameof(IsActive), IsUnique = true)]
    public class AccountLicense
    {
        public AccountLicense()
        {
            CreatedDate = DateTime.UtcNow;
            IsActive = true;
        }

        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        [MaxLength(50)]
        public string LicenseId { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime? ExpirationDate { get; set; }   
        public bool? IsActive { get; set; }  
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; } = null!;

        public bool IsLicenseActive()
        {
            return IsActive == true;
        }
    }
}
