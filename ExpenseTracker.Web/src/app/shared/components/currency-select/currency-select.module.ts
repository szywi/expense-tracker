import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CurrencySelectComponent } from './currency-select.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import {ReactiveFormsModule} from '@angular/forms';

@NgModule({
  imports: [CommonModule, MatAutocompleteModule, MatInputModule, ReactiveFormsModule],
  declarations: [CurrencySelectComponent],
  exports: [CurrencySelectComponent],
})
export class CurrencySelectModule {}
