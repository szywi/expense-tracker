import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExpenseModel, ExpensesModel, UpsertExpenseModel } from './expense.model';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ExpenseApiService {
  constructor(private readonly httpClient: HttpClient) {}

  getExpenses(pageNr?: number, pageSize?: number): Observable<ExpensesModel> {
    const params: {
      [param: string]: number;
    } = {};

    if (pageNr != null) params['pageNr'] = pageNr;
    if (pageSize != null) params['pageSize'] = pageSize;

    return this.httpClient.get<ExpensesModel>(`${environment.baseUrl}/api/expenses`, {
      params: params,
      headers: { accept: 'application/json' },
    });
  }

  addExpense(expense: UpsertExpenseModel): Observable<ExpenseModel> {
    return this.httpClient.request<ExpenseModel>('post', `${environment.baseUrl}/api/expenses`, { body: expense, headers: {} });
  }

  editExpense(key: string, expense: UpsertExpenseModel): Observable<void> {
    return this.httpClient.request<void>('put', `${environment.baseUrl}/api/expenses/${encodeURIComponent(key)}`, {
      body: expense,
      headers: { accept: 'application/json' },
    });
  }

  deleteExpense(key: string): Observable<void> {
    return this.httpClient.request<void>('delete', `${environment.baseUrl}/api/expenses/${encodeURIComponent(key)}`, {
      headers: { accept: 'application/json' },
    });
  }
}
