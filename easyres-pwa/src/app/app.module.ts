import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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
import { BestelOptiesComponent } from './bestel-opties/bestel-opties.component';
import { BestellingenComponent } from './bestellingen/bestellingen.component';
import { ScanComponent } from './scan/scan.component';

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
    BestelOptiesComponent,
    BestellingenComponent,
    ScanComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    BrowserAnimationsModule
  ],
  providers: [
    RestaurantService,
    BestellingService,
    MsalService,
    MsalGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
