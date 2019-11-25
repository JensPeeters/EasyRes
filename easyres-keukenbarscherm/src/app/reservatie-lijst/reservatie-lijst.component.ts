import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../services/restaurant.service';
import { MsalService } from '../services/msal.service';
import { IReservatie } from '../services/common.service';
import { IUitbater } from '../services/user.service';

@Component({
  selector: 'app-reservatie-lijst',
  templateUrl: './reservatie-lijst.component.html',
  styleUrls: ['./reservatie-lijst.component.scss']
})
export class ReservatieLijstComponent implements OnInit {

  reservaties: IReservatie[];
  restaurantid: number = 1;
  uitbater: IUitbater;
  aantal: number = 10;

  constructor(private ResService : RestaurantService, private MsalService : MsalService) {
    if(MsalService.isLoggedIn()){
      MsalService.isUitbater();
      MsalService.GetUitbaterRestaurantId();
    }
   }

  async ngOnInit() {
    this.ResService.GetReservationsByRestaurantID(this.restaurantid).subscribe(res => {
      this.reservaties = res;
    })
  }

  isUserLoggedIn(){
    return this.MsalService.isLoggedIn();
  }

  Annuleer(reservatieId){
    this.ResService.DeleteReservationByID(reservatieId).subscribe(a => {
      this.ResService.GetReservationsByRestaurantID(this.restaurantid).subscribe(result => {
        this.reservaties = result;
      })
    });
  }

  isEmpty(arr){
    if (!(arr.length > 0)){return true;}
    else{return false;}
  }

  showMore(){
    this.aantal += 10;
  }

}
