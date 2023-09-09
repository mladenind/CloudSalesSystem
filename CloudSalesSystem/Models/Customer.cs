using System.ComponentModel.DataAnnotations;

namespace CloudSalesSystem.Models
{
    public class Customer
    {
        public Customer() 
        {
            CreatedDate = DateTime.UtcNow;
            Name = string.Empty;
            Email = string.Empty;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }   
    }
}
