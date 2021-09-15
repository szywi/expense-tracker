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
            services.AddDbContext<ExpenseDbContext>(
                (sp, options) =>
                {
                    // todo simon: Configure DB

#if DEBUG
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
#endif
                });
        }
    }
}