
using System.ComponentModel.DataAnnotations;

namespace IMS.Infrastructure.EFModels
{
    public class CategoryEF
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string? CategoryDescription { get; set; }

        public DateTime? DeletedAT { get; set; }

        //Navigational property
        public ICollection<ItemEF> Items { get; set; }
    }
}
