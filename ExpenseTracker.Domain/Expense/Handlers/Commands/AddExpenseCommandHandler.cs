using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Expense.Dtos.Commands;
using MediatR;

namespace ExpenseTracker.Domain.Expense.Handlers.Commands
{
    public sealed class AddExpenseCommandHandler : IRequestHandler<AddExpenseCommand, Unit>
    {
        public Task<Unit> Handle(AddExpenseCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}