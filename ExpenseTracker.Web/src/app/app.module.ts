import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from './core/core.module';
import { HttpClientModule } from '@angular/common/http';
import { MatToolbarModule } from '@angular/material/toolbar';

@NgModule({
  imports: [HttpClientModule, BrowserModule, AppRoutingModule, BrowserAnimationsModule, CoreModule, MatToolbarModule],
  declarations: [AppComponent],
  bootstrap: [AppComponent],
})
export class AppModule {}
