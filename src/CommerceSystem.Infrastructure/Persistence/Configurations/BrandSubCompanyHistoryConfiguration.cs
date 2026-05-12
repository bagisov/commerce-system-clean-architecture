using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Configurations
{
    public class BrandSubCompanyHistoryConfiguration : IEntityTypeConfiguration<BrandSubCompanyHistory>
    {
        public void Configure(EntityTypeBuilder<BrandSubCompanyHistory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.EnteredAtUtc).IsRequired();

            builder.Property(x => x.LeftAtUtc).IsRequired();

            builder.HasOne(x => x.SubCompany)
                .WithMany()
                .HasForeignKey(x => x.SubCompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Brand)
                .WithMany()
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
