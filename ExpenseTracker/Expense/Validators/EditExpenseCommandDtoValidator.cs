using ExpenseTracker.Domain.Expense.Dtos.Commands;
using FluentValidation;

namespace ExpenseTracker.Expense.Validators
{
    public sealed class EditExpenseCommandDtoValidator : AbstractValidator<EditExpenseCommandDto>
    {
        public EditExpenseCommandDtoValidator()
        {
            this.RuleFor(x => x.Recipient).MaximumLength(1000);
            this.RuleFor(x => x.Amount).NotEmpty().ScalePrecision(4, 19);
            this.RuleFor(x => x.Type).NotEmpty();

            // todo simon: (P-1) Validate ISO code
        }
    }
}