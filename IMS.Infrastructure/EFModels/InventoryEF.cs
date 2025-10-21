
using System.ComponentModel.DataAnnotations;

namespace IMS.Infrastructure.EFModels
{
    public class InventoryEF
    {
        [Key]
        public int InventoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        public int QuantityAvailable { get; set; } = 0;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public DateTime? DeletedAT { get; set; }

        //Navigation property
        public ICollection<ItemEF> Items { get; set; }

    }
}
