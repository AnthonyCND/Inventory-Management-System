using IMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Infrastructure.EFModels
{
    public class ItemEF
    {
        [Key]
        public int ItemId { get; set; }

        [StringLength(200)]
        public string ItemName { get; set; }

        [StringLength(200)]
        public string? ItemDescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [StringLength(100)]
        public string UnitOfMeasure { get; set; } //Pieces, boxes, kg etc.

        [StringLength(100)]
        public ItemStatus Status { get; set; }

        public DateTime? DeletedAT { get; set; }

        public int CategoryId { get; set; }

        public int InventoryId { get; set; }

        //Navigation Properties
        
        public CategoryEF Category { get; set; }

        public InventoryEF Inventory { get; set; }

        public ICollection<PurchaseOrderEF> PurchaseOrders { get; set; }

        public ICollection<SalesOrderEF> SalesOrders { get; set; }
    }
}
