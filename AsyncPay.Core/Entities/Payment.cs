using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AsyncPay.Core.Entities;

sealed class Payment : EntityBase
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

}
