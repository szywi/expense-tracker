using ExpenseTracker.Domain.Expense.Models;
using ExpenseTracker.Domain.Expense.Models.Enums;
using ExpenseTracker.Domain.Utils.Mediator.Behaviors;
using MediatR;

namespace ExpenseTracker.Domain.Expense.Dtos.Commands
{
    public sealed class AddExpenseCommandDto : IRequest<ExpenseAggregate>, ILogSuspiciousExpensesBehavior
    {
        public string Recipient { get; set; } = default!;

        public ExpenseTypeEnum Type { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyIsoCode { get; set; } = default!;
    }
}