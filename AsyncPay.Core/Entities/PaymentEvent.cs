using AsyncPay.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncPay.Core.Entities;

public sealed class PaymentEvent : EntityBase
{
    public Guid PaymentId { get; private set; }

    public PaymentStatus FromStatus { get; private set; }
    public PaymentStatus ToStatus { get; private set; }
    public string? Reason { get; private set;}
    public DateTime OcurredAt { get; private set; }

    //EF 
    private PaymentEvent() { }

    public PaymentEvent(Guid paymentId, PaymentStatus fromStatus, PaymentStatus toStatus, string? reason = null)
    {
        if (paymentId == Guid.Empty)
            throw new ArgumentException("Id do pagamento inválido");
        PaymentId = paymentId;
        FromStatus = fromStatus;
        ToStatus = toStatus;
        Reason = reason;
        OcurredAt = DateTime.UtcNow;
    }
}
