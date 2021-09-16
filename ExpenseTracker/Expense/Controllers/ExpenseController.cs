using System;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Expense.Dtos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Expense.Controllers
{
    [ApiController]
    [Route("expenses")]
    public sealed class ExpenseController : ControllerBase
    {
        private readonly Lazy<IMediator> mediator;

        public ExpenseController(Lazy<IMediator> mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetExpenses(CancellationToken cancellationToken)
        {
            var query = new ExpenseQuery();

            var expenses = await this.mediator.Value.Send(query, cancellationToken);

            return this.Ok(expenses);
        }
    }
}