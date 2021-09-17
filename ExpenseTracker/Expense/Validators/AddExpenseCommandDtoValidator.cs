using ExpenseTracker.Domain.Expense.Dtos.Commands;
using FluentValidation;

namespace ExpenseTracker.Expense.Validators
{
    public sealed class AddExpenseCommandDtoValidator : AbstractValidator<AddExpenseCommandDto>
    {
        public AddExpenseCommandDtoValidator()
        {
            // todo simon: (P-1) Validate ISO code
        }
    }
}