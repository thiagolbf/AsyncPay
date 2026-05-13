using AsyncPay.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncPay.Infrastructure.Data.Mappings;

public class RefreshTokenMapping : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasMaxLength(450) // Padrão Identity para IDs
            .HasColumnType("varchar(450)");

        builder.Property(x => x.Token)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnType("varchar(500)");

        builder.Property(x => x.ExpiresAt)
            .IsRequired()
            .HasColumnType("timestamptz");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamptz");

        builder.Property(x => x.IsRevoked)
            .IsRequired()
            .HasColumnType("boolean");

        builder.Property(x => x.ReplacedByToken)
            .HasMaxLength(500)
            .HasColumnType("varchar(500)");

        // FK para Application User
        //builder.HasOne<ApplicationUser>()
        builder.HasOne(u => u.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
