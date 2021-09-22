import { ChangeDetectionStrategy, Component } from '@angular/core';
import { AddExpenseDlgService } from './add-expense/add-expense-dlg.service';

@Component({
  selector: 'v-expense-root',
  templateUrl: './expense-root.component.html',
  styleUrls: ['./expense-root.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ExpenseRootComponent {
  constructor(public readonly addExpenseDlg: AddExpenseDlgService) {}

  onAddExpenseClicked(): void {
    this.addExpenseDlg.open();
  }
}
