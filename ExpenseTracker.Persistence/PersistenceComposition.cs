using ExpenseTracker.Domain.Utils.Persistence;
using ExpenseTracker.Persistence.Context;
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
            services.AddScoped<IExpenseDbContext>(provider => provider.GetService<ExpenseDbContext>());
            
            services.AddDbContext<ExpenseDbContext>(
                (_, options) =>
                {
                    // todo simon: (P-1) Configure DB
#if DEBUG
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
#endif
                });
        }
    }
}