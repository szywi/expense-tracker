using System;
using MediatR;

namespace ExpenseTracker.Domain.Expense.Dtos.Commands
{
    public sealed class DeleteExpenseCommand : IRequest<Unit>
    {
        public DeleteExpenseCommand(Guid key)
        {
            this.Key = key;
        }
        
        public Guid Key { get; }
    }
}