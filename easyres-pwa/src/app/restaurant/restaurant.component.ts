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
  sorterenOp: string = "Aanbevolen";
  
  constructor(private ResService : RestaurantService) { }

  zoeknaam: string;
  zoekterm: string;
  sorteerKeuzes: string[] = ["Aanbevolen","Naam","Type","Soort","Gemeente","Land"];
  async ngOnInit() {
    this.GetRestaurants();
  }
  Zoeken(){
    this.zoekterm = `naam=${this.zoeknaam}`;
    this.ResService.GetRestaurants(this.zoekterm).subscribe(restaurants => {
      this.Restaurants = restaurants;
    })
  }
  Sorteren(item){
    this.sorterenOp = item;
    this.ResService.sortBy = item;
    if(this.zoeknaam != null && this.zoeknaam != "")
      this.Zoeken();
    else
      this.GetRestaurants();
  }
  GetRestaurants(){
    this.ResService.GetRestaurants().subscribe(restaurants => {
      this.Restaurants = restaurants;
    })
  }
}