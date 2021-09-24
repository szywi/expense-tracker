import { MatDialog } from '@angular/material/dialog';
import { AddExpenseDlgComponent } from './add-expense-dlg.component';
import { Injectable } from '@angular/core';

// todo simon: (P-2) Add types

@Injectable()
export class AddExpenseDlgService {
  constructor(public readonly dlg: MatDialog) {}

  async open(): Promise<any> {
    const dialogRef = this.dlg.open(AddExpenseDlgComponent, {
      width: '600px',
    });

    const result = await dialogRef.afterClosed().toPromise();

    if (result) return Promise.resolve(result);
    else return Promise.reject();
  }
}
