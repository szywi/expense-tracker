import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmationDlgComponent } from './confirmation-dlg.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { ConfirmationDlgService } from './confirmation-dlg.service';

@NgModule({
  imports: [CommonModule, MatDialogModule, MatButtonModule],
  declarations: [ConfirmationDlgComponent],
  providers: [ConfirmationDlgService],
})
export class ConfirmationDialogModule {}
