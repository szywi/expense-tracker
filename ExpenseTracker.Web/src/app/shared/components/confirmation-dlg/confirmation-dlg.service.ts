import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDlgComponent } from './confirmation-dlg.component';

@Injectable()
export class ConfirmationDlgService {
  constructor(public readonly dlg: MatDialog) {}

  async open(): Promise<void> {
    const dialogRef = this.dlg.open(ConfirmationDlgComponent, {
      width: '600px',
    });

    const result = await dialogRef.afterClosed().toPromise();

    if (result) return Promise.resolve();
    else return Promise.reject();
  }
}
