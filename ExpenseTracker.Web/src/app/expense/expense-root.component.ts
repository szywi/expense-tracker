import { ChangeDetectionStrategy, Component } from '@angular/core';
import { ExpenseDlgService } from './expense-dlg/expense-dlg.service';
import { ExpenseModel, UpsertExpenseModel } from 'generated-api';
import { ConfirmationDlgService } from '../shared/components/confirmation-dlg/confirmation-dlg.service';
import { ExpenseService } from './services/expense.service';

const noop = () => {};

@Component({
  selector: 'v-expense-root',
  templateUrl: './expense-root.component.html',
  styleUrls: ['./expense-root.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ExpenseRootComponent {
  constructor(
    private readonly expenseService: ExpenseService,
    private readonly addExpenseDlg: ExpenseDlgService,
    private readonly confirmationDlg: ConfirmationDlgService
  ) {}

  addExpense(): void {
    this.addExpenseDlg.open().then(async (expense: UpsertExpenseModel) => {
      await this.expenseService.addExpense(expense);
    }, noop);
  }

  editExpense(expense: ExpenseModel): void {
    this.addExpenseDlg.open(expense).then(async (modifiedExpense: UpsertExpenseModel) => {
      await this.expenseService.editExpense(expense.key, modifiedExpense);
    }, noop);
  }

  deleteExpense(key: string): void {
    this.confirmationDlg.open().then(async () => {
      await this.expenseService.deleteExpense(key);
    }, noop);
  }
}
