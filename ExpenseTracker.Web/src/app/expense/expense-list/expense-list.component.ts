import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'v-expense-list',
  templateUrl: './expense-list.component.html',
  styleUrls: ['./expense-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ExpenseListComponent {
  displayedColumns = ['recipient', 'amount', 'type', 'buttons'];

  dataSource = [
    {
      recipient: 'FooBar',
      amount: '100 CHF',
      type: 'Food',
    },
    {
      recipient: 'B',
      amount: '100 CHF',
      type: 'Food',
    },
  ];
}
