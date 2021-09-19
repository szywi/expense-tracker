import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'v-expense-root',
  templateUrl: './expense-root.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ExpenseRootComponent {}
