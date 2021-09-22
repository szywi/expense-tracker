import { Component } from '@angular/core';

// todo simon: (P-2) Add linter
// todo simon: (P-3) Typescript generation
@Component({
  selector: 'app-root',
  template: `
    <v-layout>
      <router-outlet></router-outlet>
    </v-layout>
  `,
})
export class AppComponent {}
