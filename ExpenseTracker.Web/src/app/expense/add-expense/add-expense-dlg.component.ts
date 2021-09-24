import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ExpenseTypeEnum } from '../../shared/generated-api/expensetype.enum';

@Component({
  selector: 'v-add-expense-dlg',
  templateUrl: './add-expense-dlg.component.html',
  styleUrls: ['./add-expense-dlg.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AddExpenseDlgComponent {
  readonly ExpenseTypes = Object.keys(ExpenseTypeEnum).filter((x: string) => x !== ExpenseTypeEnum.None);

  recipient = new FormControl(undefined, [Validators.required, Validators.maxLength(1000)]);
  amount = new FormControl(undefined, [Validators.required, Validators.min(0), Validators.pattern(/^\d{0,19}[.,]?\d{0,4}$/)]);
  currency = new FormControl(undefined, [Validators.required]);
  type = new FormControl(undefined, [Validators.required]);

  expense = new FormGroup({
    recipient: this.recipient,
    amount: this.amount,
    currency: this.currency,
    type: this.type,
  });

  constructor(public readonly dialogRef: MatDialogRef<AddExpenseDlgComponent>) {}

  onSaveClicked() {
    if (!this.expense.valid) return;
    this.dialogRef.close(this.expense.value);
  }

  onCancelClicked(): void {
    this.dialogRef.close();
  }
}
