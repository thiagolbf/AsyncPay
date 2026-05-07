using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncPay.Core.Entities;

public sealed class Merchant : EntityBase
{
    public string Name { get; private set; } = string.Empty;

    public string Document { get; private set; } = string.Empty;

    public string BankAccount { get; private set; } = string.Empty;

    public DateTime CreatedAt { get; private set; }

    //Navegação
    public ICollection<Payment> Payments { get; private set; } = new List<Payment>();

    //EF
    private Merchant() { }

    public Merchant(string name, string document, string bankAccount)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome do comerciante é requirido");

        if (string.IsNullOrWhiteSpace(document))
            throw new ArgumentException("Documento do comerciante é requirido");

        if (string.IsNullOrWhiteSpace(bankAccount))
            throw new ArgumentException("Conta do banco é requirida");

        Name = name;
        Document = document;
        BankAccount = bankAccount;
        CreatedAt = DateTime.Now;
    }

}
