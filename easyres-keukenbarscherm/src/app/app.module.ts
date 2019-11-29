import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { KeukenComponent } from './keuken/keuken.component';
import { BarComponent } from './bar/bar.component';
import { DataService } from './services/data.service';
import { MsalService } from './services/msal.service';
import { StartComponent } from './start/start.component';
import { UserService } from './services/user.service';
import { ControlePaneelComponent } from './controle-paneel/controle-paneel.component';
import { ReservatieLijstComponent } from './reservatie-lijst/reservatie-lijst.component';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    KeukenComponent,
    BarComponent,
    StartComponent,
    ControlePaneelComponent,
    ReservatieLijstComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    DataService,
    MsalService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
