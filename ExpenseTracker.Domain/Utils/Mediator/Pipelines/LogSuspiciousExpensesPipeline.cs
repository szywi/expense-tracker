using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Utils.Mediator.Behaviors;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Domain.Utils.Mediator.Pipelines
{
    public sealed class LogSuspiciousExpensesPipeline<TCommand, TResponse> : IPipelineBehavior<TCommand, TResponse>
        where TCommand : ILogSuspiciousExpensesBehavior
    {
        private readonly ILogger<LogSuspiciousExpensesPipeline<TCommand, TResponse>> logger;

        public LogSuspiciousExpensesPipeline(ILogger<LogSuspiciousExpensesPipeline<TCommand, TResponse>> logger)
        {
            this.logger = logger;
        }

        public Task<TResponse> Handle(TCommand request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (request.Recipient.Contains("Suspicious recipient"))
            {
                this.logger.LogWarning("Suspicious recipient detected!");
            }

            return next();
        }
    }
}