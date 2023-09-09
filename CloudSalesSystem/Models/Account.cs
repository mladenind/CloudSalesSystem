using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudSalesSystem.Models
{
    public class Account
    {
        public Account()
        {
            CreatedDate = DateTime.UtcNow;
            Name = string.Empty;
        }
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; } = null!;
    }
}
