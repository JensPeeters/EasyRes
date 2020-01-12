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
import { FacturenComponent } from './facturen/facturen.component';
import { FactuurComponent } from './facturen/factuur/factuur.component';
import { NoUitbaterComponent } from './no-uitbater/no-uitbater.component';
import { NoRestaurantComponent } from './no-restaurant/no-restaurant.component';
import { FactuurMoreInfoComponent } from './factuur-more-info/factuur-more-info.component';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    KeukenComponent,
    BarComponent,
    StartComponent,
    ControlePaneelComponent,
    ReservatieLijstComponent,
    FacturenComponent,
    FactuurComponent,
    NoUitbaterComponent,
    NoRestaurantComponent,
    FactuurMoreInfoComponent,
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
