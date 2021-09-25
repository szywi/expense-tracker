import { ChangeDetectionStrategy, Component, EventEmitter, Output } from '@angular/core';
import { ExpenseModel } from 'generated-api';
import { ExpenseService } from '../services/expense.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'v-expense-list',
  templateUrl: './expense-list.component.html',
  styleUrls: ['./expense-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ExpenseListComponent {
  readonly displayedColumns: string[] = ['recipient', 'amount', 'type', 'transactionTime', 'actions'];

  readonly expenses$: Observable<ExpenseModel[]>;
  readonly pageNr$: Observable<number>;
  readonly totalExpenses$: Observable<number>;
  readonly isLoading$: Observable<boolean>;

  @Output() edit = new EventEmitter<ExpenseModel>();
  @Output() delete = new EventEmitter<string>();

  constructor(private readonly expenseService: ExpenseService) {
    this.expenses$ = this.expenseService.expenses$;
    this.pageNr$ = this.expenseService.pageNr$;
    this.totalExpenses$ = this.expenseService.totalExpenses$;
    this.isLoading$ = this.expenseService.isLoading$;
  }

  get pageSize(): number {
    return this.expenseService.pageSize;
  }

  loadExpenses(pageNr: number): void {
    this.expenseService.loadExpenses(pageNr);
  }

  trackByKey(index: number, item: { key: string }): string {
    return item.key;
  }
}
