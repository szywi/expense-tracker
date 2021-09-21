using System;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Expense.Dtos.Commands;
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

        // todo simon: (P-1) Get expenses
        // todo simon: (P-2) Filter and search expenses
        [HttpGet]
        public async Task<IActionResult> GetExpenses(CancellationToken cancellationToken)
        {
            var query = new ExpenseQuery();
            var expenses = await this.mediator.Value.Send(query, cancellationToken);

            return this.Ok(expenses);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(AddExpenseCommandDto command)
        {
            var expense = await this.mediator.Value.Send(command);
            return this.Created(expense.Key.ToString(), expense);
        }

        [HttpPut("{key:guid}")]
        public Task EditExpense(Guid key, [FromBody] EditExpenseCommandDto commandDto)
        {
            return this.mediator.Value.Send(commandDto);
        }

        [HttpDelete("{key:guid}")]
        public async Task DeleteExpense(Guid key)
        {
            var command = new DeleteExpenseCommand(key);
            await this.mediator.Value.Send(command);
        }
    }
}