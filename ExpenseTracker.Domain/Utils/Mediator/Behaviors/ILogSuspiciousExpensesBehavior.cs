using ExpenseTracker.Domain.Expense.Dtos.Commands;

namespace ExpenseTracker.Domain.Utils.Mediator.Behaviors
{
    /// <summary>
    /// Behavior assigned for a command that should log suspicious expense.
    /// </summary>
    public interface ILogSuspiciousExpensesBehavior
    {
        public UpsertExpenseCommandDto Command { get; }
    }
}