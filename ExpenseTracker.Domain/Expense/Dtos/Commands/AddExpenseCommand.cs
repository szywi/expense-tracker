using MediatR;

namespace ExpenseTracker.Domain.Expense.Dtos.Commands
{
    public sealed class AddExpenseCommand : IRequest<Unit>
    {
    }
}