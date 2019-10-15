import { Component, OnInit } from '@angular/core';
import { RestaurantService, IRestaurant } from '../services/restaurant.service';
import { ThrowStmt } from '@angular/compiler';


@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})
export class RestaurantComponent implements OnInit {

  Restaurants : IRestaurant[];
  
  constructor(private ResService : RestaurantService) { }

  zoeknaam: string;
  zoekterm: string;
  async ngOnInit() {
    this.GetRestaurants();
  }
  Zoeken(){
    this.zoekterm = `naam=${this.zoeknaam}`;
    this.ResService.GetRestaurants(this.zoekterm).subscribe(restaurants => {
      this.Restaurants = restaurants;
    })
  }
  GetRestaurants(){
    this.ResService.GetRestaurants().subscribe(restaurants => {
      this.Restaurants = restaurants;
    })
  }
}