import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCardModule } from '@angular/material/card';
import { ExpenseListComponent } from './expense-list.component';

@NgModule({
  imports: [CommonModule, MatTableModule, MatIconModule, MatButtonModule, MatInputModule, MatPaginatorModule, MatCardModule],
  declarations: [ExpenseListComponent],
  exports: [ExpenseListComponent],
})
export class ExpenseListModule {}
