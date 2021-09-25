using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Expense.Models;
using ExpenseTracker.Domain.Utils.Mediator.Decorators;
using ExpenseTracker.Domain.Utils.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Domain.Expense.Handlers.Commands
{
    public sealed class
        UpsertExpenseCommandHandler : IRequestHandler<AddExpenseDecorator, ExpenseAggregate>,
            IRequestHandler<EditExpenseDecorator, Unit>
    {
        private readonly IExpenseDbContext dbContext;

        public UpsertExpenseCommandHandler(IExpenseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ExpenseAggregate> Handle(AddExpenseDecorator request,
            CancellationToken cancellationToken)
        {
            var command = request.Command;

            var expense = new ExpenseAggregate(command.Recipient,
                command.Type,
                command.Amount,
                command.CurrencyIsoCode);

            this.dbContext.Expenses.Add(expense);
            await this.dbContext.SaveChangesAsync(cancellationToken);

            return expense;
        }

        public async Task<Unit> Handle(EditExpenseDecorator request,
            CancellationToken cancellationToken)
        {
            var command = request.Command;

            var expense = await this.dbContext.Expenses
                .FirstAsync(x => x.Key == request.Key, cancellationToken);

            expense.Update(command);
            await this.dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}