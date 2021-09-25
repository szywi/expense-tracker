using System;
using ExpenseTracker.Domain.Expense.Dtos.Commands;
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

#pragma warning disable 8618 // Non-nullable field is uninitialized - needed by EF
        private ExpenseAggregate()
#pragma warning restore 8618 // Non-nullable field is uninitialized - needed by EF
        {
        }
        
        public Guid Key { get; private set; }

        public string Recipient { get; private set; }

        public PriceModel Price { get; private set; }

        public ExpenseTypeEnum Type { get; private set; }

        public DateTime TransactionTimeUtc { get; private set; }

        public void Update(UpsertExpenseCommandDto command)
        {
            this.Recipient = command.Recipient;
            this.Price = new PriceModel(command.Amount, command.CurrencyIsoCode);
            this.Type = command.Type;
        }
    }
}