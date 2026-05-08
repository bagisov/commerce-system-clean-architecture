using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Status)
                   .IsRequired();

            // Brand → SubCompany
            builder.HasOne<SubCompany>()
                   .WithMany()
                   .HasForeignKey(x => x.SubCompanyId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
