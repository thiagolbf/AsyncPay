using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncPay.Core.Enum;

public enum PaymentStatus
{
    Pending = 1,
    Processing = 2,
    Completed = 3,
    Failed = 4
}
