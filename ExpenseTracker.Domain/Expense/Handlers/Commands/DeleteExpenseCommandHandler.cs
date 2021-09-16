using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Expense.Dtos.Commands;
using MediatR;

namespace ExpenseTracker.Domain.Expense.Handlers.Commands
{
    public sealed class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, Unit>
    {
        public Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}