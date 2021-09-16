using System.Linq;
using ExpenseTracker.Domain.Expense.Models;
using MediatR;

namespace ExpenseTracker.Domain.Expense.Dtos.Queries
{
    public sealed class ExpenseQuery : IRequest<IQueryable<ExpenseAggregate>>
    {
    }
}