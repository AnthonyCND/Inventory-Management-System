
using System.ComponentModel.DataAnnotations;

namespace IMS.Infrastructure.EFModels
{
    public class CustomerEF
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(100)]
        public string ContactNumber { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        public DateTime? DeletedAT { get; set; }

        //Navigation property
        public ICollection<SalesOrderEF> SalesOrders { get; set; }
    }
}
