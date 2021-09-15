using ExpenseTracker.Domain.Expense.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseTracker.Persistence.Mappings.Expense
{
    public sealed class ExpenseConfiguration : IEntityTypeConfiguration<ExpenseAggregate>
    {
        public void Configure(EntityTypeBuilder<ExpenseAggregate> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}