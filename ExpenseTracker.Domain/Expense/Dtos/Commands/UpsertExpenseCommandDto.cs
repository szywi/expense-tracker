using ExpenseTracker.Domain.Expense.Models.Enums;

namespace ExpenseTracker.Domain.Expense.Dtos.Commands
{
    public class UpsertExpenseCommandDto
    {
        public string Recipient { get; set; } = default!;

        public ExpenseTypeEnum Type { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyIsoCode { get; set; } = default!;
    }
}