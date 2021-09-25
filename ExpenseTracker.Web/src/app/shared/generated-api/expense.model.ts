import { ExpenseTypeEnum } from './expensetype.enum';

export interface ExpensesModel {
  pages: number;
  total: number;
  currentPage: number;
  expenses: ExpenseModel[];
}

export interface ExpenseModel {
  key: string;
  recipient: string;
  amount: number;
  currencyIsoCode: string;
  type: ExpenseTypeEnum;
  transactionTimeUtc: string;
}

export interface UpsertExpenseModel {
  recipient: string;
  amount: number;
  currencyIsoCode: string;
  type: ExpenseTypeEnum;
}
