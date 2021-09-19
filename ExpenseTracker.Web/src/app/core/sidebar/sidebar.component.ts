import { Component, ChangeDetectionStrategy, ViewChild, AfterViewInit } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver, BreakpointState } from '@angular/cdk/layout';
import { delay } from 'rxjs/operators';

@Component({
  selector: 'v-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SidebarComponent implements AfterViewInit {
  @ViewChild(MatSidenav) sidenav!: MatSidenav;

  constructor(private readonly observer: BreakpointObserver) {}

  ngAfterViewInit() {
    this.observer
      .observe(['(max-width: 800px)'])
      .pipe(delay(1))
      .subscribe(async (res: BreakpointState) => {
        if (res.matches) {
          this.sidenav.mode = 'over';
          await this.sidenav.close();
        } else {
          this.sidenav.mode = 'side';
          await this.sidenav.open();
        }
      });
  }
}
