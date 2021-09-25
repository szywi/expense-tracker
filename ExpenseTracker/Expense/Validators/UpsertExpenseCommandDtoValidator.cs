using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Domain.Expense.Dtos.Commands;
using FluentValidation;

namespace ExpenseTracker.Expense.Validators
{
    public sealed class AddExpenseCommandDtoValidator : AbstractValidator<UpsertExpenseCommandDto>
    {
        private HashSet<string> CurrencyCodes = new(new[]
        {
            "CAD", "EUR", "JPY", "PLN", "CHF", "GBP", "USD",
        });

        public AddExpenseCommandDtoValidator()
        {
            this.RuleFor(x => x.Recipient).MaximumLength(1000);
            this.RuleFor(x => x.Amount).NotEmpty().ScalePrecision(4, 19);
            this.RuleFor(x => x.Type).NotEmpty();

            this.RuleFor(x => x.CurrencyIsoCode)
                .Must(x => this.CurrencyCodes.Contains(x))
                .WithMessage(
                    $"'{nameof(UpsertExpenseCommandDto.CurrencyIsoCode)}' must be one of supported currencies: {string.Join(',', this.CurrencyCodes.ToList())}");
        }
    }
}