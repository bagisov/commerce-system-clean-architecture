using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Configurations
{
    public class StockMovementConfiguration
           : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.ToTable("StockMovements");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.QuantityChange)
                .IsRequired();

            builder.Property(x => x.MovementType)
                .IsRequired();

            builder.Property(x => x.Note)
                .HasMaxLength(500);

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

            builder.HasIndex(x => new { x.BranchId, x.ProductVariantId });

            builder.HasIndex(x => x.CreatedAtUtc);
        }
    }
}
