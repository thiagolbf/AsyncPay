using AsyncPay.Core.Entities;
using AsyncPay.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncPay.Infrastructure.Data.Mappings;

public class PaymentMapping : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments"); // Não precisaria

        builder.HasKey(x => x.Id);

        builder.Property(x => x.MerchantId)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasMaxLength(450) //padrão Identity para IDs
            .HasColumnType("varchar(450)");

        builder.Property(x => x.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.Currency)
            .IsRequired()
            .HasMaxLength(3) // BRL, USD, EUR...
            .HasColumnType("varchar(3)");

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasColumnType("varchar(20)");

        builder.Property(x => x.ExternalId)
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamptz");

        builder.Property(x => x.UpdatedAt)
            .HasColumnType("timestamptz");

        // FK para Merchant
        builder.HasOne<Merchant>()
            .WithMany(m => m.Payments)
            .HasForeignKey(x => x.MerchantId)
            .OnDelete(DeleteBehavior.Restrict);

        // FK para Application User
        builder.HasOne<ApplicationUser>()
            .WithMany(u => u.Payments)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
