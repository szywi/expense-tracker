import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { ExpenseDlgComponent } from './expense-dlg.component';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ExpenseDlgService } from './expense-dlg.service';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CurrencySelectModule } from '../../shared/components/currency-select/currency-select.module';

@NgModule({
  imports: [CommonModule, MatDialogModule, MatInputModule, MatButtonModule, MatSelectModule, CurrencySelectModule, FormsModule, ReactiveFormsModule],
  providers: [ExpenseDlgService],
  declarations: [ExpenseDlgComponent],
  exports: [ExpenseDlgComponent],
})
export class ExpenseDlgModule {}
