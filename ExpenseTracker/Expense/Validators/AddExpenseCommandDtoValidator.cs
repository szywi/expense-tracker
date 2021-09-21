﻿using ExpenseTracker.Domain.Expense.Dtos.Commands;
using FluentValidation;

// todo simon: (P-2) Share
namespace ExpenseTracker.Expense.Validators
{
    public sealed class AddExpenseCommandDtoValidator : AbstractValidator<AddExpenseCommandDto>
    {
        public AddExpenseCommandDtoValidator()
        {
            this.RuleFor(x => x.Recipient).MaximumLength(1000);
            this.RuleFor(x => x.Amount).NotEmpty().ScalePrecision(4, 19);
            this.RuleFor(x => x.Type).NotEmpty();

            // todo simon: (P-1) Validate ISO code
        }
    }
}