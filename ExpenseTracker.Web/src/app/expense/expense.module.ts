import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpenseRootComponent } from './expense-root.component';
import { Route, RouterModule } from '@angular/router';
import { ExpenseDlgModule } from './expense-dlg/expense-dlg.module';
import { ExpenseListModule } from './expense-list/expense-list.module';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';

const expenseRoutes: Route[] = [
  {
    path: '',
    component: ExpenseRootComponent,
  },
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(expenseRoutes), ExpenseDlgModule, ExpenseListModule, MatIconModule, MatCardModule, MatButtonModule],
  declarations: [ExpenseRootComponent],
})
export class ExpenseModule {}
