
using System.ComponentModel.DataAnnotations;

namespace IMS.Infrastructure.EFModels;

public partial class SupplierEF
{
    [Key]
    public int SupplierId { get; set; }

    [StringLength(100)]
    public string SupplierName { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }

    [StringLength(200)]
    public string? Description { get; set; }

    [StringLength(200)]
    public string? ContactPerson { get; set; }

    [StringLength(200)]
    public string? ContactNumber { get; set; }

    [StringLength(200)]
    public string? ContactEmail { get; set; }

    public DateTime? DeletedAT { get; set; }

    // Navigation property

    public ICollection<PurchaseOrderEF> PurchaseOrders { get; set; }
}
