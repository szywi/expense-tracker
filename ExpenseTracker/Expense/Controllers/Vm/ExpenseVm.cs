using System;
using ExpenseTracker.Domain.Expense.Models.Enums;

namespace ExpenseTracker.Expense.Controllers.Vm
{
    public sealed class ExpenseVm
    {
        public Guid Key { get; set; }
        
        public string Recipient { get; set; } = default!;


        public decimal Amount { get; set; }

        public string CurrencyIsoCode { get; set; } = default!;
        
        public ExpenseTypeEnum Type { get; set; }

        public DateTime TransactionTimeUtc { get; set; }
    }
}