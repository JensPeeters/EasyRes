import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { KeukenComponent } from './keuken/keuken.component';
import { BarComponent } from './bar/bar.component';
import { DataService } from './services/data.service';
import { MsalService } from './services/msal.service';
import { StartComponent } from './start/start.component';
import { UserService } from './services/user.service';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    KeukenComponent,
    BarComponent,
    StartComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [
    DataService,
    MsalService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
