using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public DateTime Date { get; private set; }

        public Transaction(decimal amount, TransactionType type)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Type = type;
            Date = DateTime.UtcNow;
        }

        public bool IsCredit()
            => Type == TransactionType.Credit;

        public bool IsDebit()
            => Type == TransactionType.Debit;
    }
}
