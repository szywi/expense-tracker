import { MatDialog } from '@angular/material/dialog';
import { ExpenseDlgComponent } from './expense-dlg.component';
import { Injectable } from '@angular/core';
import { ExpenseModel, UpsertExpenseModel } from 'generated-api';

@Injectable()
export class ExpenseDlgService {
  constructor(public readonly dlg: MatDialog) {}

  async open(expense: ExpenseModel | null = null): Promise<UpsertExpenseModel> {
    const dialogRef = this.dlg.open(ExpenseDlgComponent, {
      width: '600px',
      disableClose: true,
      data: expense,
    });

    const result = await dialogRef.afterClosed().toPromise();

    if (result) return Promise.resolve(result);
    else return Promise.reject();
  }
}
