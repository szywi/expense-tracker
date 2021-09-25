using System.Collections.Generic;

namespace ExpenseTracker.Expense.Controllers.Vm
{
    public sealed class ExpensesVm
    {
        public long Pages { get; set; }
        
        public long Total { get; set; }

        public int CurrentPage { get; set; }

        public IReadOnlyList<ExpenseVm> Expenses { get; set; } = new List<ExpenseVm>();
    }
}