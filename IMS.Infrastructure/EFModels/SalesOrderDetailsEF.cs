
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Infrastructure.EFModels
{
    public class SalesOrderDetailsEF
    {
        [Key]
        public int SalesOrderDetailsId { get; set; }

        [Required]
        public int SoldQuantity { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        public DateTime? DeletedAT { get; set; }

        //Foreign key props
        public int SalesOrderId { get; set; }

        public int ItemId { get; set; }

        //Navigation property
        public SalesOrderEF SalesOrder { get; set; }

        public ItemEF Item { get; set; }
    }
}
