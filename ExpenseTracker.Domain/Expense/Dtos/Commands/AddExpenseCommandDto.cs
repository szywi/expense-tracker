using ExpenseTracker.Domain.Expense.Models.Enums;
using ExpenseTracker.Domain.Utils.Mediator.Behaviors;
using MediatR;

namespace ExpenseTracker.Domain.Expense.Dtos.Commands
{
    public sealed class AddExpenseCommandDto : IRequest<Unit>, ILogSuspiciousExpensesBehavior
    {
        public string Recipient { get; }

        public ExpenseTypeEnum Type { get; }

        public decimal Amount { get; }

        public string CurrencyIsoCode { get; }
    }
}