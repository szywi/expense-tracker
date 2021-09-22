import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout/layout.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { MatListModule } from '@angular/material/list';

// todo simon: (P-3) Error handling
@NgModule({
  imports: [CommonModule, MatSidenavModule, MatToolbarModule, MatIconModule, MatDividerModule, MatButtonModule, RouterModule, MatListModule],
  declarations: [LayoutComponent],
  exports: [LayoutComponent],
})
export class CoreModule {}
