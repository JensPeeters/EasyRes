import { Component, OnInit } from '@angular/core';
import { RestaurantService, IRestaurant } from '../services/restaurant.service';

@Component({
  selector: 'app-favorieten',
  templateUrl: './favorieten.component.html',
  styleUrls: ['./favorieten.component.scss']
})
export class FavorietenComponent implements OnInit {

  constructor(private ResService : RestaurantService) { }
  Restaurants: IRestaurant[] = [];
  zoekterm: string = "";
  zoeknaam: string = "";
  ngOnInit() {
    this.GetRestaurants();
  }
  GetRestaurants(){
    this.ResService.GetFavorites("davy",this.zoeknaam).subscribe(gebruiker => {
      this.Restaurants = gebruiker.restaurants;
    });
  }

  Zoeken(){
    this.zoekterm = `naam=${this.zoeknaam}`;
    this.GetRestaurants();
  }

}
