import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { KeukenComponent } from './keuken/keuken.component';
import { BarComponent } from './bar/bar.component';
import { DataService } from './data.service';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    KeukenComponent,
    BarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path: "keuken", component: KeukenComponent},
      {path: "bar", component: BarComponent},
      {path: "", redirectTo:"keuken", pathMatch:"full"},
      {path: "**", redirectTo:"keuken", pathMatch:"full"},
    ])
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
