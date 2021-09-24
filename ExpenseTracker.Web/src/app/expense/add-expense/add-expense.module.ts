import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { AddExpenseDlgComponent } from './add-expense-dlg.component';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { AddExpenseDlgService } from './add-expense-dlg.service';
import { MatSelectModule } from '@angular/material/select';
import { CurrencySelectModule } from '../../shared/components/currency-select/currency-select.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [CommonModule, MatDialogModule, MatInputModule, MatButtonModule, MatSelectModule, CurrencySelectModule, FormsModule, ReactiveFormsModule],
  providers: [AddExpenseDlgService],
  declarations: [AddExpenseDlgComponent],
  exports: [AddExpenseDlgComponent],
})
export class AddExpenseModule {}
