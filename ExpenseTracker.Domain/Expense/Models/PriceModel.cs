namespace ExpenseTracker.Domain.Expense.Models
{
    public sealed class PriceModel
    {
        public PriceModel(decimal amount, string currencyIsoCode)
        {
            this.Amount = amount;
            this.CurrencyIsoCode = currencyIsoCode;
        }

        public decimal Amount { get; }
        
        public string CurrencyIsoCode { get; }
    }
}