using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Domain.Utils.Mediator
{
    internal static class MediatorComposition
    {
        public static void ComposeMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DomainComposition).Assembly);
        }
    }
}