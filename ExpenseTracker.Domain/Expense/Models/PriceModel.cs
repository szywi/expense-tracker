namespace ExpenseTracker.Domain.Expense.Models
{
    public sealed class PriceModel
    {
        public PriceModel(decimal amount, string currencyIsoCode)
        {
            this.Amount = amount;
            this.CurrencyIsoCode = currencyIsoCode;
        }

        public string CurrencyIsoCode { get; }

        public decimal Amount { get; }
    }
}