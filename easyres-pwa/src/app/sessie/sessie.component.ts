import { Component, OnInit } from '@angular/core';
import { RestaurantService, IRestaurant } from '../services/restaurant.service';

@Component({
  selector: 'app-sessie',
  templateUrl: './sessie.component.html',
  styleUrls: ['./sessie.component.scss']
})
export class SessieComponent implements OnInit {

  Restaurants : IRestaurant[];
  TafelNr : number = 4;
  constructor(private resServ : RestaurantService) { }

  ngOnInit() {
    this.resServ.GetRestaurants().subscribe(restaurants => {
      this.Restaurants = restaurants;
    });
  }

}
