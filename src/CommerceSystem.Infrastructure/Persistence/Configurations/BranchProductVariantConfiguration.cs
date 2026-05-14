using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Configurations
{
    public class BranchProductVariantConfiguration : IEntityTypeConfiguration<BranchProductVariant>
    {
        public void Configure(EntityTypeBuilder<BranchProductVariant> builder)
        {
            builder.ToTable("BranchProductVariants");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status)
                   .IsRequired();

            builder.HasOne(x => x.Branch)
                   .WithMany()
                   .HasForeignKey(x => x.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProductVariant)
                   .WithMany()
                   .HasForeignKey(x => x.ProductVariantId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.BranchId, x.ProductVariantId })
                   .IsUnique();
        }
    }
}
