import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { RestaurantComponent } from './restaurant/restaurant.component';


const routes: Routes = [
  {path:"restaurant", component:RestaurantComponent},
  {path:"", redirectTo:"restaurant", pathMatch:"full"},
  {path:"**", redirectTo:"home", pathMatch:"full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
