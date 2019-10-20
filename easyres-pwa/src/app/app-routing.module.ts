import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { RestaurantInfoComponent } from './restaurant-info/restaurant-info.component';
import { ReservatieComponent } from './reservatie/reservatie.component';
import { SessieComponent } from './sessie/sessie.component';
import { BestelComponent } from './bestel/bestel.component';
import { VerstuurBestellingComponent } from './verstuur-bestelling/verstuur-bestelling.component';
import { BesteldeProductenComponent } from './bestelde-producten/bestelde-producten.component';

const routes: Routes = [
  {path:"restaurant", component:RestaurantComponent},
  {path: 'restaurant/:restaurant.restaurantId', component: RestaurantInfoComponent },
  {path:"reservatie/:id", component:ReservatieComponent},
  //{path:"betaal/:id", component:BetaalComponent},
  {path:"bestel/:id/:TafelNr/producten", component: BesteldeProductenComponent},
  {path:"bestel/:id/:TafelNr/verstuur", component: VerstuurBestellingComponent},
  {path:"bestel/:id/:TafelNr", component: BestelComponent},
  {path:"actief", component:SessieComponent},
  {path:"", redirectTo:"restaurant", pathMatch:"full"},
  {path:"**", redirectTo:"home", pathMatch:"full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
