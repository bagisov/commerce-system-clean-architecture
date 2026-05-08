using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Color)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Size)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.PurchasePrice)
                   .HasPrecision(18, 2);

            builder.Property(x => x.BaseSellingPrice)
                   .HasPrecision(18, 2);

            builder.Property(x => x.Status)
                   .IsRequired();

            // Product → Brand
            builder.HasOne<Brand>()
                   .WithMany()
                   .HasForeignKey(x => x.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Product → ProductCategory
            builder.HasOne<ProductCategory>()
                   .WithMany()
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
