import { Injectable } from '@angular/core';
import { BehaviorSubject, combineLatest, Observable, throwError, timer } from 'rxjs';
import { ExpenseApiService, ExpenseModel, ExpensesModel, UpsertExpenseModel } from 'generated-api';
import { catchError, map, switchMap, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ExpenseService {
  private readonly pageNrSubject = new BehaviorSubject<number>(0);
  private readonly totalExpensesSubject = new BehaviorSubject<number>(0);
  private readonly isLoadingSubject = new BehaviorSubject<boolean>(false);

  readonly pageSize = 5;

  readonly expenses$: Observable<ExpenseModel[]>;
  readonly pageNr$ = this.pageNrSubject.asObservable();
  readonly totalExpenses$ = this.totalExpensesSubject.asObservable();
  readonly isLoading$ = this.isLoadingSubject.asObservable();

  constructor(private readonly expenseApiService: ExpenseApiService) {
    this.expenses$ = this.getExpenses();
  }

  loadExpenses(pageNr: number): void {
    this.pageNrSubject.next(pageNr);
  }

  async addExpense(expense: UpsertExpenseModel): Promise<void> {
    await this.expenseApiService.addExpense(expense).toPromise();
    this.reloadExpenses();
  }

  async editExpense(key: string, expense: UpsertExpenseModel): Promise<void> {
    await this.expenseApiService.editExpense(key, expense).toPromise();
    this.reloadExpenses();
  }

  async deleteExpense(key: string): Promise<void> {
    await this.expenseApiService.deleteExpense(key).toPromise();
    this.reloadExpenses();
  }

  private getExpenses() {
    const getExpenses$ = (pageNr: number) =>
      combineLatest([timer(500), this.expenseApiService.getExpenses(pageNr, this.pageSize)]).pipe(map((x: [number, ExpensesModel]) => x[1]));

    return this.pageNr$.pipe(
      tap(() => this.isLoadingSubject.next(true)),
      switchMap((pageNr: number) => getExpenses$(pageNr + 1)),
      tap((pagedExpenses: ExpensesModel) => {
        this.totalExpensesSubject.next(pagedExpenses.total);
        this.isLoadingSubject.next(false);
      }),
      map((pagedExpenses: ExpensesModel) => pagedExpenses.expenses),
      catchError((err) => {
        this.isLoadingSubject.next(false);
        return throwError(err);
      })
    );
  }

  private reloadExpenses() {
    this.pageNrSubject.next(0);
  }
}
