using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Expense.Dtos.Queries;
using ExpenseTracker.Domain.Expense.Models;
using ExpenseTracker.Domain.Utils.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Domain.Expense.Handlers.Queries
{
    // todo simon: (P-2) Maybe it's better to not stream responses?
    public sealed class ExpenseQueryHandler : IRequestHandler<ExpenseQuery, IQueryable<ExpenseAggregate>>
    {
        private readonly IExpenseDbContext expenseDbContext;

        public ExpenseQueryHandler(IExpenseDbContext expenseDbContext)
        {
            this.expenseDbContext = expenseDbContext;
        }

        public Task<IQueryable<ExpenseAggregate>> Handle(ExpenseQuery request, CancellationToken cancellationToken)
        {
            var expenseQuery = this.expenseDbContext.Expenses
                .AsNoTracking();

            return Task.FromResult(expenseQuery);
        }
    }
}