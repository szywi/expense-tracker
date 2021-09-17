using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Expense.Dtos.Commands;
using ExpenseTracker.Domain.Utils.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Domain.Expense.Handlers.Commands
{
    public sealed class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand, Unit>
    {
        private readonly IExpenseDbContext dbContext;

        public DeleteExpenseCommandHandler(IExpenseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = await this.dbContext.Expenses
                .Where(x => x.Key == request.Key)
                .FirstOrDefaultAsync(cancellationToken);

            if (expense == null) return Unit.Value;

            this.dbContext.Expenses.Remove(expense);
            await this.dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}