using ExpenseTracker.Domain.Expense.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Domain.Utils.Persistence
{
    public interface IExpenseDbContext
    {
        DbSet<ExpenseAggregate> Expenses { get; }
    }
}