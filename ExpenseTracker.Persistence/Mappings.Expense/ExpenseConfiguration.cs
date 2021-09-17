using ExpenseTracker.Domain.Expense.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseTracker.Persistence.Mappings.Expense
{
    public sealed class ExpenseConfiguration : IEntityTypeConfiguration<ExpenseAggregate>
    {
        public void Configure(EntityTypeBuilder<ExpenseAggregate> builder)
        {
            builder.ToTable("Expenses");
            
            builder.HasKey("Rid");
            builder.HasAlternateKey(x => x.Key);

            // todo simon: (P-1) Configure price in DB
            // todo simon: (P-2) Think about relations (is it better to store relations)
            builder.OwnsOne(x => x.Price,
                x =>
                {
                    x.Property(y => y.CurrencyIsoCode).HasMaxLength(3);
                });
            
            builder.Property(x => x.TransactionTimeUtc).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}