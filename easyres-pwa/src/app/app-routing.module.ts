import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { RestaurantInfoComponent } from './restaurant-info/restaurant-info.component';
import { ReservatieComponent } from './reservatie/reservatie.component';

const routes: Routes = [
  {path:"restaurant", component:RestaurantComponent, data: {animation: "restaurant"}},
  {path: 'restaurant/:restaurant.restaurantId', component: RestaurantInfoComponent, data: {animation: 'restaurantInfo'} },
  {path:"reservatie/:id", component:ReservatieComponent, data: {animation: 'reservatie'}},
  {path:"", redirectTo:"restaurant", pathMatch:"full", data: {animation: 'restaurant'}},
  {path:"**", redirectTo:"restaurant", pathMatch:"full", data: {animation: 'restaurant'}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
