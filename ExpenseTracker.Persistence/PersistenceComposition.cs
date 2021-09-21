using ExpenseTracker.Domain.Utils.Persistence;
using ExpenseTracker.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Persistence
{
    public static class PersistenceComposition
    {
        public static void ComposePersistence(this IServiceCollection services)
        {
            services.ComposeDb();
        }

        private static void ComposeDb(this IServiceCollection services)
        {
            services.AddScoped<IExpenseDbContext>(provider => provider.GetRequiredService<ExpenseDbContext>());

            services.AddDbContext<ExpenseDbContext>((sp, options) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("ExpensesDb");

                options.UseSqlServer(connectionString, o => o.CommandTimeout(300).EnableRetryOnFailure());
#if DEBUG
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
#endif
            });
        }
    }
}