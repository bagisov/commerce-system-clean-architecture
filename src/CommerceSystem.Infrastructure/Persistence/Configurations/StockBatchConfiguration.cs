using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Configurations
{
    public class StockBatchConfiguration
            : IEntityTypeConfiguration<StockBatch>
    {
        public void Configure(EntityTypeBuilder<StockBatch> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.InitialQuantity)
                .IsRequired();

            builder.Property(x => x.RemainingQuantity)
                .IsRequired();

            builder.Property(x => x.UnitCost)
                .HasPrecision(18, 2);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired();

            builder.HasOne(x => x.Branch)
                .WithMany()
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ProductVariant)
                .WithMany()
                .HasForeignKey(x => x.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
