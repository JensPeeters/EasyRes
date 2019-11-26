import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../services/restaurant.service';
import { MsalService } from '../services/msal.service';
import { IRestaurant } from '../services/common.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-controle-paneel',
  templateUrl: './controle-paneel.component.html',
  styleUrls: ['./controle-paneel.component.scss']
})
export class ControlePaneelComponent implements OnInit {

  currentSettingsRestaurant: IRestaurant;
  updatedSettingsRestaurant: IRestaurant;
  soorten: string[] = ["Restaurant","Taverne","Bistro","Trattoria"]
  restaurantId: number;

  constructor(private ResService : RestaurantService, private MsalService: MsalService, private userService: UserService) {
   }

  ngOnInit() {
    this.userService.isuitbater(this.MsalService.getUserObjectId()).subscribe(res =>{
      this.restaurantId = res.restaurantId;
      this.ResService.GetRestaurantByID(this.restaurantId).subscribe(res => {
        this.currentSettingsRestaurant = res;
        this.updatedSettingsRestaurant = res;
      })
    });
  }

  submit(){
    console.log(this.updatedSettingsRestaurant);
    this.ResService.PutRestaurant(this.updatedSettingsRestaurant).subscribe(a => {
      console.log(a);
      alert("Wijzigingen opgeslagen.");
    });
  }

  reset(){
    this.ResService.GetRestaurantByID(this.restaurantId).subscribe(res => {
      this.updatedSettingsRestaurant = res;
    })
  }

  restaurantSoort(soort){
    this.updatedSettingsRestaurant.soort = soort;
  }

  append(arr){
    arr.push({aantal: 0, naam: "", prijs:0})
  }
}