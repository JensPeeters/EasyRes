import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { RestaurantService, IRestaurant } from '../services/restaurant.service';

@Component({
  selector: 'app-restaurant-info',
  templateUrl: './restaurant-info.component.html',
  styleUrls: ['./restaurant-info.component.scss']
})
export class RestaurantInfoComponent implements OnInit {
  @Input() inputRestaurantID: number;
  @Output() goingBack: EventEmitter<boolean> =   new EventEmitter();

  constructor(private ResService : RestaurantService) { }

  restaurant: IRestaurant;
  collapsed: boolean = false;

  async ngOnInit() {
    this.ResService.GetRestaurantByID(this.inputRestaurantID).subscribe(result => {
      this.restaurant = result;
    })
  }
  goBack(){
    this.goingBack.emit(false);
  }
}
