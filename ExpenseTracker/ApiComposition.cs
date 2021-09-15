using ExpenseTracker.Domain;
using ExpenseTracker.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker
{
    public static class ApiComposition
    {
        public static void ComposeApi(this IServiceCollection services)
        {
            services.ComposeDomains();
            services.ComposePersistence();
        }
    }
}