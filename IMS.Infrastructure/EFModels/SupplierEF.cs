using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
}
