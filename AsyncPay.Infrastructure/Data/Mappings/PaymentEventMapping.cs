using AsyncPay.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncPay.Infrastructure.Data.Mappings;

public class PaymentEventMapping : IEntityTypeConfiguration<PaymentEvent>
{
    public void Configure(EntityTypeBuilder<PaymentEvent> builder)
    {
        builder.ToTable("PaymentEvents");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.PaymentId)
            .IsRequired()
            .HasColumnType("uuid");

        builder.Property(x => x.FromStatus)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasColumnType("varchar(20)");

        builder.Property(x => x.ToStatus)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasColumnType("varchar(20)");

        builder.Property(x => x.Reason)
            .HasMaxLength(500)
            .HasColumnType("varchar(500)");

        builder.Property(x => x.OcurredAt)
            .IsRequired()
            .HasColumnType("timestamptz");

        // FK para Payment
        builder.HasOne<Payment>()
            .WithMany(p => p.Events)
            .HasForeignKey(e => e.PaymentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
