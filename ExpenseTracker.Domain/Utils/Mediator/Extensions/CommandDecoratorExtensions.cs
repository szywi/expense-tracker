using System;
using ExpenseTracker.Domain.Expense.Dtos.Commands;
using ExpenseTracker.Domain.Utils.Mediator.Decorators;

namespace ExpenseTracker.Domain.Utils.Mediator.Extensions
{
    public static class CommandDecoratorExtensions
    {
        public static AddExpenseDecorator AsAddExpenseRequest(this UpsertExpenseCommandDto command)
            => new(command);

        public static EditExpenseDecorator AsEditExpenseRequest(this UpsertExpenseCommandDto command, Guid key)
            => new(key, command);
    }
}