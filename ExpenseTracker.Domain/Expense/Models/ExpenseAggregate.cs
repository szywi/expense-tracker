using System;
using ExpenseTracker.Domain.Expense.Models.Enums;

namespace ExpenseTracker.Domain.Expense.Models
{
    public sealed class ExpenseAggregate
    {
        public ExpenseAggregate(string recipient, ExpenseTypeEnum type, decimal amount, string currencyIsoCode)
        {
            this.Key = Guid.NewGuid();
            this.Recipient = recipient;
            this.Price = new PriceModel(amount, currencyIsoCode);
            this.Type = type;
            this.TransactionTimeUtc = DateTime.UtcNow;
        }
        
        public Guid Key { get; }

        public string Recipient { get; }

        public PriceModel Price { get; }

        // todo simon: (P-2) Make this relational
        public ExpenseTypeEnum Type { get; }

        public DateTime TransactionTimeUtc { get; }
    }
}