using ExpenseTracker.Domain.Expense.Models.Enums;
using MediatR;

namespace ExpenseTracker.Domain.Expense.Dtos.Commands
{
    public sealed class EditExpenseCommandDto : IRequest<Unit>
    {
        public string Recipient { get; }

        public ExpenseTypeEnum Type { get; }

        public decimal Amount { get; }

        public string CurrencyIsoCode { get; }
    }
}