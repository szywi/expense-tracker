import { ChangeDetectionStrategy, Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ExpenseModel, ExpenseTypeEnum } from 'generated-api';

@Component({
  selector: '',
  templateUrl: './expense-dlg.component.html',
  styleUrls: ['./expense-dlg.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ExpenseDlgComponent {
  readonly ExpenseTypes = Object.keys(ExpenseTypeEnum).filter((x: string) => x !== ExpenseTypeEnum.None);

  recipient = new FormControl(undefined, [Validators.required, Validators.maxLength(1000)]);
  amount = new FormControl(undefined, [Validators.required, Validators.min(0), Validators.pattern(/^\d{0,19}[.,]?\d{0,4}$/)]);
  currencyIsoCode = new FormControl(undefined, [Validators.required]);
  type = new FormControl(undefined, [Validators.required]);

  expense = new FormGroup({
    recipient: this.recipient,
    amount: this.amount,
    currencyIsoCode: this.currencyIsoCode,
    type: this.type,
  });

  constructor(public readonly dialogRef: MatDialogRef<ExpenseDlgComponent>, @Inject(MAT_DIALOG_DATA) expense: ExpenseModel | null) {
    this.recipient.setValue(expense?.recipient);
    this.amount.setValue(expense?.amount);
    this.currencyIsoCode.setValue(expense?.currencyIsoCode);
    this.type.setValue(expense?.type);
  }

  save(): void {
    if (!this.expense.valid) return;
    this.dialogRef.close(this.expense.value);
  }

  cancel(): void {
    this.dialogRef.close();
  }
}
