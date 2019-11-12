import { Component, OnInit } from '@angular/core';
import { RestaurantService, IRestaurant } from '../services/restaurant.service';
import { MsalService } from '../services/msal.service';

@Component({
  selector: 'app-favorieten',
  templateUrl: './favorieten.component.html',
  styleUrls: ['./favorieten.component.scss']
})
export class FavorietenComponent implements OnInit {

  constructor(private ResService : RestaurantService, private msalService: MsalService) { }
  Restaurants: IRestaurant[] = [];
  zoekterm: string = "";
  zoeknaam: string = "";
  UserId: string = "";

  async ngOnInit() {
    if(this.msalService.isLoggedIn())
      this.getUserObjectId();
    await this.GetRestaurants();
  }

  async GetRestaurants(){
    var tempGebruiker = await this.ResService.GetFavorites(this.UserId,this.zoeknaam);
    this.Restaurants = tempGebruiker.restaurants;
  }

  Zoeken(){
    this.zoekterm = `naam=${this.zoeknaam}`;
    this.GetRestaurants();
  }
  getUserObjectId(){
    this.UserId = this.msalService.getUserObjectId();
  }
  RemoveRestaurant(restaurant: IRestaurant){
    this.ResService.DeleteFavoritesByID(this.UserId,restaurant.restaurantId).subscribe();
    this.Restaurants.splice(this.Restaurants.indexOf(restaurant),1);
  }
  IsEmpty(arr){
    if (!(arr.length > 0)){return true;}
    else{return false;}
  }
}
