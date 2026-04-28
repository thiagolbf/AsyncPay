using AsyncPay.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AsyncPay.Core.Entities;

public sealed class Payment : EntityBase
{
    public Guid MerchantId { get; private set; }

    [Required]
    public string? UserId { get; private set; }

    public decimal Amount { get; private set; }

    [Required]
    public string? Currency { get; private set; }

    public PaymentStatus Status { get; private set; }

    public string? ExternalId { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    //EF
    private Payment() { }

    public Payment(Guid merchantId, string userId, decimal amount, string currency)
    {
        if (merchantId == Guid.Empty)
            throw new ArgumentException("Id Comerciante inválido");

        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("Id Usuário inválido");

        if (amount <= 0)
            throw new ArgumentException("Valor deve ser maior que zero");

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Moeda inválida");

        MerchantId = merchantId;
        UserId = userId;
        Amount = amount;
        Currency = currency;

        Status = PaymentStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }
}

