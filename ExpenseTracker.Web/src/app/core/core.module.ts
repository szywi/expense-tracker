import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from './sidebar/sidebar.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';

// todo simon: (P-3) Error handling
@NgModule({
  imports: [CommonModule, MatSidenavModule, MatToolbarModule, MatIconModule, MatDividerModule, MatButtonModule, RouterModule],
  declarations: [SidebarComponent],
  exports: [SidebarComponent],
})
export class CoreModule {}
