import { Component, OnInit, Optional, Self, AfterViewInit, OnDestroy, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { AbstractControl, ControlValueAccessor, FormControl, NgControl } from '@angular/forms';
import { map, startWith } from 'rxjs/operators';
import { merge, Observable, Subscription } from 'rxjs';

export interface Currency {
  code: string;
  text: string;
}

const Currencies: Currency[] = [
  { code: 'CAD', text: 'Canada Dollars – CAD' },
  { code: 'EUR', text: 'Euro – EUR' },
  { code: 'JPY', text: 'Japan Yen – JPY' },
  { code: 'PLN', text: 'Poland Zlotych – PLN' },
  { code: 'CHF', text: 'Switzerland Francs – CHF' },
  { code: 'GBP', text: 'United Kingdom Pounds – GBP' },
  { code: 'USD', text: 'United States Dollars – USD' },
];

@Component({
  selector: 'v-currency-select',
  templateUrl: './currency-select.component.html',
  exportAs: 'currencySelect',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CurrencySelectComponent implements OnInit, AfterViewInit, OnDestroy, ControlValueAccessor {
  readonly Currencies = Currencies;

  formControl = new FormControl();
  currencies$!: Observable<Currency[]>;

  onChange = (_: string | null) => {};

  private onTouched = () => {};
  private syncErrorsSubscription?: Subscription;

  constructor(@Optional() @Self() public ngControl: NgControl, private readonly cdr: ChangeDetectorRef) {
    if (this.ngControl != null) this.ngControl.valueAccessor = this;
  }

  ngOnInit(): void {
    this.currencies$ = this.filterCurrencies();
  }

  ngAfterViewInit(): void {
    this.syncParentFormControlErrors();
  }

  ngOnDestroy(): void {
    this.syncErrorsSubscription?.unsubscribe();
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: () => {}): void {
    this.onTouched = fn;
  }

  writeValue(code: string): void {
    const currency = this.Currencies.filter((x: Currency) => x.code === code)[0];
    this.formControl.setValue(currency);
  }

  displayCurrencyText(currency?: Currency): string {
    return currency?.text ?? '';
  }

  // angular forms don't have a way to notify custom components when form is submitted
  onSubmit(): void {
    this.cdr.markForCheck();
  }

  private filterCurrencies(): Observable<Currency[]> {
    return this.formControl.valueChanges.pipe(
      startWith(''),
      map((value: string | Currency) => (typeof value === 'string' ? value : value.text)),
      map((name: string) => {
        const filterValue = name.toLowerCase();
        return this.Currencies.filter((option: Currency) => option.text.toLowerCase().includes(filterValue));
      })
    );
  }

  private syncParentFormControlErrors() {
    if (!this.ngControl?.control) throw new Error('No from control is found.');

    const parentFormControl: AbstractControl = this.ngControl.control;

    this.formControl.setErrors(parentFormControl.errors);

    this.syncErrorsSubscription = merge(parentFormControl.statusChanges, parentFormControl.valueChanges).subscribe(() => {
      this.formControl.setErrors(this.ngControl.control!.errors);
      this.formControl.markAsTouched();
    });
  }
}
