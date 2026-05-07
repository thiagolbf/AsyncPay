using AsyncPay.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncPay.Infrastructure.Identity;

public sealed class ApplicationUser : IdentityUser
{
    public ICollection<Payment> Payments { get; private set; } = [];
}


