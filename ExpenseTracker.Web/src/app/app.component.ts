import { Component } from '@angular/core';

// todo simon: (P-2) Add linter
// todo simon: (P-3) Typescript generation
@Component({
  selector: 'app-root',
  template: `
    <v-sidebar>
      <router-outlet></router-outlet>
    </v-sidebar>
  `,
})
export class AppComponent {}
