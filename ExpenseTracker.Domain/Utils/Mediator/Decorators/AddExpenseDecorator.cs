using ExpenseTracker.Domain.Expense.Dtos.Commands;
using ExpenseTracker.Domain.Expense.Models;
using ExpenseTracker.Domain.Utils.Mediator.Behaviors;
using MediatR;

namespace ExpenseTracker.Domain.Utils.Mediator.Decorators
{
    public sealed class AddExpenseDecorator : IRequest<ExpenseAggregate>, ILogSuspiciousExpensesBehavior
    {
        public AddExpenseDecorator(UpsertExpenseCommandDto command)
        {
            this.Command = command;
        }

        public UpsertExpenseCommandDto Command { get; }
    }
}