using ExpenseTracker.Domain.Expense.Models.Enums;
using ExpenseTracker.Domain.Utils.Mediator.Behaviors;
using MediatR;

namespace ExpenseTracker.Domain.Expense.Dtos.Commands
{
    public sealed class EditExpenseCommandDto : IRequest<Unit>, ILogSuspiciousExpensesBehavior
    {
        public string Recipient { get; set; } = default!;

        public ExpenseTypeEnum Type { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyIsoCode { get; set; } = default!;
    }
}