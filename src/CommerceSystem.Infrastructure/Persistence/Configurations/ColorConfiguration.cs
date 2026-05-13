using CommerceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceSystem.Infrastructure.Persistence.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.HexCode)
                .HasMaxLength(20);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasData(
                new Color
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Black",
                    HexCode = "#000000"
                },
                new Color
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "White",
                    HexCode = "#FFFFFF"
                },
                new Color
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Blue",
                    HexCode = "#0000FF"
                },
                new Color
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Name = "Red",
                    HexCode = "#FF0000"
                },
                new Color
                {
                    Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Name = "Brown",
                    HexCode = "#8B4513"
                });
        }
    }
}
