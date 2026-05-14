using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Configurations
{
    public class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("ProductModels");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(x => x.Brand)
                .WithMany()
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.ProductVariants)
                .WithOne(x => x.ProductModel)
                .HasForeignKey(x => x.ProductModelId);

            builder.HasIndex(x => new { x.BrandId, x.CategoryId, x.Name })
                .IsUnique();
        }
    }
}
