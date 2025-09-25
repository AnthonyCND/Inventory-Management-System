using System;
using System.Collections.Generic;
using IMS.Infrastructure.EFModels;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SupplierEF> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SupplierEF>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK_Suppliers_SupplierId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
