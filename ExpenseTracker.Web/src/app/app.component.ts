import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <v-layout>
      <router-outlet></router-outlet>
    </v-layout>
  `,
})
export class AppComponent {}
