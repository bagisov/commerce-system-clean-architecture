using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PurchasePrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.BaseSellingPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasOne(x => x.ProductModel)
                .WithMany(x => x.ProductVariants)
                .HasForeignKey(x => x.ProductModelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Color)
                .WithMany()
                .HasForeignKey(x => x.ColorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Size)
                .WithMany()
                .HasForeignKey(x => x.SizeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.ProductModelId, x.ColorId, x.SizeId })
                .IsUnique();
        }
    }
}
