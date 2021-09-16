using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Expense.Dtos.Commands;
using MediatR;

namespace ExpenseTracker.Domain.Expense.Handlers.Commands
{
    public sealed class EditExpenseCommandHandler : IRequestHandler<EditExpenseCommand, Unit>
    {
        public Task<Unit> Handle(EditExpenseCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}