using ExpenseTracker.Domain.Expense.Models;
using ExpenseTracker.Persistence.Mappings.Expense;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Persistence.Context
{
    public sealed class ExpenseDbContext : DbContext
    {
        private readonly ILoggerFactory loggerFactory;

        public ExpenseDbContext(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        public DbSet<ExpenseAggregate> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (this.loggerFactory != null) optionsBuilder.UseLoggerFactory(this.loggerFactory);
        }
    }
}