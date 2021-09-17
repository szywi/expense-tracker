﻿using ExpenseTracker.Domain.Expense.Models.Enums;
using MediatR;

namespace ExpenseTracker.Domain.Expense.Dtos.Commands
{
    // todo simon: (P-2) Add logging when expense goes above threshold
    public sealed class AddExpenseCommandDto : IRequest<Unit>
    {
        public string Recipient { get; }

        public ExpenseTypeEnum Type { get; }

        public decimal Amount { get; }
        
        public string CurrencyIsoCode { get; }
    }
}