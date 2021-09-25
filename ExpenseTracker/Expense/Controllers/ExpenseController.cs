using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Expense.Dtos.Commands;
using ExpenseTracker.Domain.Utils.Mediator.Extensions;
using ExpenseTracker.Domain.Utils.Persistence;
using ExpenseTracker.Expense.Controllers.Vm;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Expense.Controllers
{
    [ApiController]
    [Route("expenses")]
    public sealed class ExpenseController : ControllerBase
    {
        private readonly Lazy<IExpenseDbContext> expenseDbContext;
        private readonly Lazy<IMediator> mediator;

        public ExpenseController(Lazy<IExpenseDbContext> expenseDbContext, Lazy<IMediator> mediator)
        {
            this.expenseDbContext = expenseDbContext;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ExpensesVm> GetExpenses(CancellationToken cancellationToken,
            [Range(1, 1000)]int pageNr = 1,
            [Range(1, 100)]int pageSize = 50)
        {
            var total = await this.expenseDbContext.Value.Expenses.CountAsync(cancellationToken);

            var expenses = await this.expenseDbContext.Value.Expenses
                .AsNoTracking()
                .Skip((pageNr - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new ExpenseVm
                {
                    Key = x.Key,
                    Recipient = x.Recipient,
                    Amount = x.Price.Amount,
                    CurrencyIsoCode = x.Price.CurrencyIsoCode,
                    Type = x.Type,
                    TransactionTimeUtc = x.TransactionTimeUtc,
                })
                .OrderBy(x => x.TransactionTimeUtc)
                .ToListAsync(cancellationToken);

            return new ExpensesVm
            {
                Total = total,
                CurrentPage = pageNr,
                Pages = (long)Math.Ceiling(total / (decimal)pageSize),
                Expenses = expenses,
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(UpsertExpenseCommandDto command)
        {
            var request = command.AsAddExpenseRequest();
            var expense = await this.mediator.Value.Send(request);

            return this.Created(expense.Key.ToString(), expense);
        }

        [HttpPut("{key:guid}")]
        public Task EditExpense(Guid key, [FromBody] UpsertExpenseCommandDto command)
        {
            var request = command.AsEditExpenseRequest(key);
            return this.mediator.Value.Send(request);
        }

        [HttpDelete("{key:guid}")]
        public async Task DeleteExpense(Guid key)
        {
            var command = new DeleteExpenseCommand(key);
            await this.mediator.Value.Send(command);
        }
    }
}