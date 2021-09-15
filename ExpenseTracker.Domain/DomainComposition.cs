using ExpenseTracker.Domain.Expense;
using ExpenseTracker.Domain.Utils.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Domain
{
    public static class DomainComposition
    {
        public static void ComposeDomains(this IServiceCollection services)
        {
            services.ComposeExpense();

            services.ComposeUtils();
        }

        private static void ComposeUtils(this IServiceCollection services)
        {
            services.ComposeMediator();
        }
    }
}