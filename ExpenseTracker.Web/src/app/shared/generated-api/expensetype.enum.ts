export const ExpenseTypeEnum = {
  None: 'None' as 'None',
  Food: 'Food' as 'Food',
  Drinks: 'Drinks' as 'Drinks',
  Other: 'Other' as 'Other',
};

export type ExpenseTypeEnum = keyof typeof ExpenseTypeEnum;
