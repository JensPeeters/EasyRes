import { Component, OnInit } from '@angular/core';
import { RestaurantService, IRestaurant } from '../services/restaurant.service';
import { MsalService } from '../services/msal.service';

@Component({
  selector: 'app-controle-paneel',
  templateUrl: './controle-paneel.component.html',
  styleUrls: ['./controle-paneel.component.scss']
})
export class ControlePaneelComponent implements OnInit {

  currentSettingsRestaurant: IRestaurant;
  restaurantId: number = 1;

  constructor(private ResService : RestaurantService, private MsalService: MsalService) {
    ResService.GetRestaurantByID(this.restaurantId).subscribe(res => {
      this.currentSettingsRestaurant = res;
      console.log(this.currentSettingsRestaurant);
    })
   }

  ngOnInit() {
  }

}
