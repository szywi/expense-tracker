import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpenseRootComponent } from './expense-root.component';
import { Route, RouterModule } from '@angular/router';
import { ExpenseListComponent } from './expense-list/expense-list.component';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';

const expenseRoutes: Route[] = [
  {
    path: '',
    component: ExpenseRootComponent,
  },
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(expenseRoutes), MatTableModule, MatIconModule, MatButtonModule, MatInputModule, MatPaginatorModule],
  declarations: [ExpenseRootComponent, ExpenseListComponent],
})
export class ExpenseModule {}
