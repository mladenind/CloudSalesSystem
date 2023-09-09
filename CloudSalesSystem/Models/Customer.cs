using System.ComponentModel.DataAnnotations;

namespace CloudSalesSystem.Models
{
    public class Customer
    {
        public Customer() 
        {
            CreatedDate = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }   
    }
}
