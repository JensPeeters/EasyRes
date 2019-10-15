import { Component, OnInit} from '@angular/core';
import { RestaurantService, IRestaurant } from '../services/restaurant.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-restaurant-info',
  templateUrl: './restaurant-info.component.html',
  styleUrls: ['./restaurant-info.component.scss']
})
export class RestaurantInfoComponent implements OnInit {

  constructor(private ResService : RestaurantService,  private route: ActivatedRoute) { }

  restaurant: IRestaurant;
  collapsed: boolean = false;
  inputRestaurantID: number;

  async ngOnInit() {
    this.route.paramMap.subscribe(params =>{
      this.inputRestaurantID = Number(params.get('restaurant.restaurantId')); 
    })
    this.ResService.GetRestaurantByID(this.inputRestaurantID).subscribe(result => {
      this.restaurant = result;
    })
  }
  goBack(){
  }
}
