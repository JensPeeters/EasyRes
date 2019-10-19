import { Component, OnInit } from '@angular/core';
import { RestaurantService, IRestaurant } from '../services/restaurant.service';


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
  types: type[] = [{naam: "Restaurant",active:true},{naam: "Taverne",active:true},{naam: "Bistro",active:true},{naam: "Trattoria",active:true}]

  async ngOnInit() {
    this.GetRestaurants();
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
  GetRestaurants(){
    var temp: IRestaurant[] = [];
    this.types.forEach(element => {
      if(element.active){
        this.ResService.GetRestaurants(`${this.zoekterm}&soort=${element.naam}`).subscribe(restaurants => {
          restaurants.forEach(element => {
            temp.push(element);
          });
        })
      }
    });
    this.Restaurants = temp;
  }
  ChangeTypes(type){
    type.active = !type.active;
    this.GetRestaurants();
  }
}
export interface type{
  naam: string;
  active: boolean;
}