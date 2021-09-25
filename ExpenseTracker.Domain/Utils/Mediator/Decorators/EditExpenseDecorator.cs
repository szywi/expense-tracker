using System;
using ExpenseTracker.Domain.Expense.Dtos.Commands;
using ExpenseTracker.Domain.Utils.Mediator.Behaviors;
using MediatR;

namespace ExpenseTracker.Domain.Utils.Mediator.Decorators
{
    public sealed class EditExpenseDecorator : IRequest<Unit>, ILogSuspiciousExpensesBehavior
    {
        public EditExpenseDecorator(Guid key, UpsertExpenseCommandDto command)
        {
            this.Key = key;
            this.Command = command;
        }

        public Guid Key { get; }

        public UpsertExpenseCommandDto Command { get; }
    }
}