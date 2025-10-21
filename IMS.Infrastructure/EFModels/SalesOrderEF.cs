
using IMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Infrastructure.EFModels
{
    public class SalesOrderEF
    {
        [Key]
        public int SalesOrderId { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public DateTime? DeletedAT { get; set; }

        //Foreign Key Prop
        public int CustomerId { get; set; }

        //Navigation property
        public CustomerEF Customer { get; set; }


    }
}
