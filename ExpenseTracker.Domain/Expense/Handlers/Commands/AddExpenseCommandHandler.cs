using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Expense.Dtos.Commands;
using ExpenseTracker.Domain.Expense.Models;
using ExpenseTracker.Domain.Utils.Persistence;
using MediatR;

namespace ExpenseTracker.Domain.Expense.Handlers.Commands
{
    public sealed class AddExpenseCommandHandler : IRequestHandler<AddExpenseCommandDto, ExpenseAggregate>
    {
        private readonly IExpenseDbContext dbContext;

        public AddExpenseCommandHandler(IExpenseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ExpenseAggregate> Handle(AddExpenseCommandDto request, CancellationToken cancellationToken)
        {
            var expense = new ExpenseAggregate(request.Recipient,
                request.Type,
                request.Amount,
                request.CurrencyIsoCode);

            this.dbContext.Expenses.Add(expense);
            await this.dbContext.SaveChangesAsync(cancellationToken);

            return expense;
        }
    }
}