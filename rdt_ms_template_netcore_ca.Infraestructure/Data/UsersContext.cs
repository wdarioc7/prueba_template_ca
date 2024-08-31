using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using rdt_ms_template_netcore_ca.Core.Entities;

namespace rdt_ms_template_netcore_ca.Infraestructure.Data;

public partial class UsersContext : DbContext
{
    public UsersContext()
    {
    }

    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductEntity> Products { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.CategorieId, "categorie_id");

            entity.HasIndex(e => e.MediaId, "media_id");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyPrice)
                .HasPrecision(25)
                .HasColumnName("buy_price");
            entity.Property(e => e.CategorieId).HasColumnName("categorie_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.MediaId)
                .HasDefaultValueSql("'0'")
                .HasColumnName("media_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Quantity)
                .HasMaxLength(50)
                .HasColumnName("quantity");
            entity.Property(e => e.SalePrice)
                .HasPrecision(25)
                .HasColumnName("sale_price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
