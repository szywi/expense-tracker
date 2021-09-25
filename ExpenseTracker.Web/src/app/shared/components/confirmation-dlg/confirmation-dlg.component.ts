import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: '',
  templateUrl: './confirmation-dlg.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ConfirmationDlgComponent {
  constructor(public readonly dialogRef: MatDialogRef<ConfirmationDlgComponent>) {}

  acknowledge(): void {
    this.dialogRef.close(true);
  }

  cancel(): void {
    this.dialogRef.close();
  }
}
