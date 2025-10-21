
using IMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Infrastructure.EFModels
{
    public class PurchaseOrderEF
    {
        [Key]
        public int PurchaseOrderId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Totalamount { get; set; } = decimal.Zero;

        [Required]
        public PurchaseOrderStatus Status { get; set; } = PurchaseOrderStatus.Pending;

        [Required]
        public DateTime OrderedDate { get; set; } = DateTime.Now;

        public DateTime? ArrivedDate { get; set; }

        public DateTime? DeletedAT { get; set; }

        //Foreign Key Prop
        public int SupplierId { get; set; }

        //Navigation property
        public SupplierEF Supplier { get; set; }

        public ICollection<PurchaseOrderDetailsEF> PurchaseOrderDetails { get; set; }


    }
}
