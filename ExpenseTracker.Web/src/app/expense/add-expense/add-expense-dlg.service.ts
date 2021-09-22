import { MatDialog } from '@angular/material/dialog';
import { AddExpenseDlgComponent } from './add-expense-dlg.component';
import { Injectable } from '@angular/core';

@Injectable()
export class AddExpenseDlgService {
  constructor(public readonly dlg: MatDialog) {}

  open() {
    const dialogRef = this.dlg.open(AddExpenseDlgComponent, {
      width: '600px',
    });

    return dialogRef.afterClosed();
  }
}
