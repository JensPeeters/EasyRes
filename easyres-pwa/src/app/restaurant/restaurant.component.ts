import { Component, OnInit } from '@angular/core';
import { RestaurantService, IRestaurant } from '../services/restaurant.service';
import { MsalService } from '../services/msal.service';


@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})
export class RestaurantComponent implements OnInit {

  Restaurants : IRestaurant[];
  sorterenOp: string = "Aanbevolen";
  
  constructor(private ResService : RestaurantService, private msalService: MsalService) { }

  zoeknaam: string;
  zoekterm: string;
  sorteerKeuzes: string[] = ["Aanbevolen","Naam","Type","Soort","Gemeente","Land"];
  types: type[] = [{naam: "Restaurant",active:true},{naam: "Taverne",active:true},{naam: "Bistro",active:true},{naam: "Trattoria",active:true}]
  UserId: string;

  async ngOnInit() {
    this.GetUserObjectId();
    await this.GetRestaurants();
  }
  Zoeken(){
    this.zoekterm = `naam=${this.zoeknaam}`;
    this.GetRestaurants();
  }
  Sorteren(item){
    this.sorterenOp = item;
    this.ResService.sortBy = item;
    if(this.zoeknaam != null && this.zoeknaam != "")
      this.Zoeken();
    else
      this.GetRestaurants();
  }
  async GetRestaurants(){
    var temp: IRestaurant[] = [];
    for(var element of this.types){
      if (element.active) {
        var tempRestaurants = await this.ResService.GetRestaurants(`${this.zoekterm}&soort=${element.naam}`);
        tempRestaurants.forEach(element => {
          temp.push(element);
        });
      }
    }
    this.Restaurants = temp;
    await this.CheckFavorites();
  }
  ChangeTypes(type){
    type.active = !type.active;
    this.GetRestaurants();
  }
  isUserLoggedIn() {
    return this.msalService.isLoggedIn();
  }
  GetUserObjectId(){
    this.UserId = this.msalService.getUserObjectId();
  }
  AddDeleteFavorites(Restaurantid: number, index){
    if(this.RestaurantsFavoriteBooleans[index]){
      this.ResService.DeleteFavoritesByID(this.UserId, Restaurantid).subscribe();
    }
    else{
      this.ResService.PostFavorite(this.UserId,Restaurantid).subscribe();
    }
    this.RestaurantsFavoriteBooleans[index] = !this.RestaurantsFavoriteBooleans[index];
  }
  FavoriteRestaurants: IRestaurant[] = []
  async GetUserFavorites(){
    var tempGebruiker = await this.ResService.GetFavorites(this.UserId,"");
    this.FavoriteRestaurants = tempGebruiker.restaurants;
  }
  RestaurantsFavoriteBooleans: boolean[] = [];
  async CheckFavorites(){
    await this.GetUserFavorites();
    this.RestaurantsFavoriteBooleans = [];
    this.Restaurants.forEach(element => {
      if(this.FavoriteRestaurants.find(x => x.restaurantId === element.restaurantId))
        this.RestaurantsFavoriteBooleans.push(true);
      else
      this.RestaurantsFavoriteBooleans.push(false);
    });
  }
}
export interface type{
  naam: string;
  active: boolean;
}