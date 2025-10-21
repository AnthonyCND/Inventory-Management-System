
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Infrastructure.EFModels
{
    public class PurchaseOrderDetailsEF
    {
        [Key]
        public int PurchaseOrderDetailsId { get; set; }

        [Required]
        public int QuantityOrdered { get; set; }

        public int QuantityReceived { get; set; } = 0;

        public DateTime? DeletedAT { get; set; }

        //Foreign key props
        public int PurchaseOrderId { get; set; }

        public int ItemId { get; set; }

        //Navigation property
        public PurchaseOrderEF PurchaseOrder { get; set; }
        public ItemEF Item { get; set; }
    }
}
