using IMS.Domain.Enums;
using IMS.Infrastructure.EFModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

    public virtual DbSet<CustomerEF> Customers { get; set; }

    public virtual DbSet<CategoryEF> Categories { get; set; }   

    public virtual DbSet<ItemEF> Items { get; set; }

    public virtual DbSet<InventoryEF> Inventory { get; set; }

    public virtual DbSet<PurchaseOrderEF>  PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderDetailsEF> PurchaseOrderDetails { get; set; }

    public virtual DbSet<SalesOrderEF> SalesOrders { get; set; }

    public virtual DbSet<SalesOrderDetailsEF> SalesOrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SupplierEF>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK_Suppliers_SupplierId");
        });

        modelBuilder.Entity<ItemEF>()
       .Property(i => i.Status)
       .HasConversion<string>(); //Store and retrieve as the enum

        modelBuilder.Entity<PurchaseOrderEF>()
       .Property(i => i.Status)
       .HasConversion<string>();

        modelBuilder.Entity<SalesOrderEF>()
       .Property(i => i.Status)
       .HasConversion<string>();

        //Disable cascade deletion
        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
        .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
