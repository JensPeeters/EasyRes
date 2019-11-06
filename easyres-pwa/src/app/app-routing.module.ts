import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { RestaurantInfoComponent } from './restaurant-info/restaurant-info.component';
import { ReservatieComponent } from './reservatie/reservatie.component';
import { SessieComponent } from './sessie/sessie.component';
import { BestelComponent } from './bestel/bestel.component';
import { VerstuurBestellingComponent } from './verstuur-bestelling/verstuur-bestelling.component';
import { BesteldeProductenComponent } from './bestelde-producten/bestelde-producten.component';
import { FavorietenComponent } from './favorieten/favorieten.component';
import { ReservatieLijstComponent } from './reservatie-lijst/reservatie-lijst.component';
import { MsalGuard } from './guard/msal.guard';
import { BestelOptiesComponent } from './bestel-opties/bestel-opties.component';
import { BestellingService } from './services/bestelling.service';
import { BestellingenComponent } from './bestellingen/bestellingen.component';

const routes: Routes = [
  {path: 'restaurant', component: RestaurantComponent, data: {animation: 'restaurant'}},
  {path: 'restaurant/:restaurant.restaurantId', component: RestaurantInfoComponent, data: {animation: 'restaurantInfo'} },
  {path: 'reservatie/:id', component: ReservatieComponent, canActivate: [MsalGuard], data: {animation: 'reservatie'}},
  {path: 'reservatie-lijst', component: ReservatieLijstComponent, canActivate: [MsalGuard], data: {animation: 'reservatielijst'}},
  // {path:"betaal/:id", component:BetaalComponent},
  {path: 'bestel/:id/:TafelNr/bestellingen', component: BestellingenComponent},
  {path: 'bestel/:id/:TafelNr/producten', component: BesteldeProductenComponent},
  {path: 'bestel/:id/:TafelNr/verstuur', component: VerstuurBestellingComponent},
  {path: 'bestel/:id/:TafelNr/menu', component: BestelComponent},
  {path: 'bestel/:id/:TafelNr', component: BestelOptiesComponent},
  {path: 'actief', component: SessieComponent, canActivate: [MsalGuard]},
  {path: 'favorieten', component: FavorietenComponent, canActivate: [MsalGuard], data: {animation: 'favorieten'}},
  {path: '', redirectTo: 'restaurant', pathMatch: 'full', data: {animation: 'restaurant'}},
  {path: '**', redirectTo: 'restaurant', pathMatch: 'full', data: {animation: 'restaurant'}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
