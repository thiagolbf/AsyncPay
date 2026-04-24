using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncPay.Core.Entities;

public abstract class EntityBase
{
    public Guid Id { get; private set; } = Guid.NewGuid();
}
