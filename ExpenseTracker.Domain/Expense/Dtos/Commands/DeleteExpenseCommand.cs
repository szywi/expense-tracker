using MediatR;

namespace ExpenseTracker.Domain.Expense.Dtos.Commands
{
    public sealed class DeleteExpenseCommand : IRequest<Unit>
    {
    }
}