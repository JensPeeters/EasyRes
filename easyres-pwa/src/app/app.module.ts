import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ZXingScannerModule } from '@zxing/ngx-scanner';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { RestaurantService } from './services/restaurant.service';
import { ReservatieComponent } from './reservatie/reservatie.component';
import { MsalService } from './services/msal.service';
import { RestaurantInfoComponent } from './restaurant-info/restaurant-info.component';
import { SessieComponent } from './sessie/sessie.component';
import { BestelComponent } from './bestel/bestel.component';
import { VerstuurBestellingComponent } from './verstuur-bestelling/verstuur-bestelling.component';
import { BestellingService } from './services/bestelling.service';
import { BesteldeProductenComponent } from './bestelde-producten/bestelde-producten.component';
import { FavorietenComponent } from './favorieten/favorieten.component';
import { ReservatieLijstComponent } from './reservatie-lijst/reservatie-lijst.component';
import { MsalGuard } from './guard/msal.guard';
import { BestellingenComponent } from './bestellingen/bestellingen.component';
import { ProfielComponent } from './profiel/profiel.component';
import { ScanComponent } from './scan/scan.component';
import { SessionService } from './services/session.service';
import { Ng2CompleterModule } from 'ng2-completer';
import { UserService } from './services/user.service';
import { GoogleAnalyticsService } from './services/google-analytics.service';
import { FactuurComponent } from './factuur/factuur.component';
import { FacturenComponent } from './facturen/facturen.component';
import { FacturenfactuurComponent } from './facturenfactuur/facturenfactuur.component';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    RestaurantComponent,
    ReservatieComponent,
    ReservatieLijstComponent,
    RestaurantInfoComponent,
    SessieComponent,
    BestelComponent,
    VerstuurBestellingComponent,
    BesteldeProductenComponent,
    FavorietenComponent,
    BestellingenComponent,
    ProfielComponent,
    ScanComponent,
    FactuurComponent,
    FacturenComponent,
    FacturenfactuurComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ZXingScannerModule,
    HttpClientModule,
    FormsModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    BrowserAnimationsModule,
    Ng2CompleterModule
  ],
  providers: [
    RestaurantService,
    BestellingService,
    SessionService,
    MsalService,
    MsalGuard,
    UserService,
    GoogleAnalyticsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
