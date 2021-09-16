using MediatR;

namespace ExpenseTracker.Domain.Expense.Dtos.Commands
{
    public sealed class EditExpenseCommand : IRequest<Unit>
    {
    }
}