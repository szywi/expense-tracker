import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'v-add-expense-dlg',
  templateUrl: './add-expense-dlg.component.html',
  styleUrls: ['./add-expense-dlg.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddExpenseDlgComponent {
  constructor(public readonly dialogRef: MatDialogRef<AddExpenseDlgComponent>) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
