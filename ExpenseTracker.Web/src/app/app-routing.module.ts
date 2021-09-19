import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PreloadSelectedModulesStrategy } from './core/preload/preload-selected-modules.strategy';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'expenses',
      },
      {
        path: 'expenses',
        loadChildren: () => import('./expense/expense.module').then((x) => x.ExpenseModule),
        data: { preload: true },
      },
    ],
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: '',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadSelectedModulesStrategy })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
