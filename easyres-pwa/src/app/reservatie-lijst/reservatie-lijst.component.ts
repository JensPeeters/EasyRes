import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../services/restaurant.service';
import { MsalService } from '../services/msal.service';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { IReservatie } from '../services/common.service';

@Component({
  selector: 'app-reservatie-lijst',
  templateUrl: './reservatie-lijst.component.html',
  styleUrls: ['./reservatie-lijst.component.scss']
})
export class ReservatieLijstComponent implements OnInit {

  reservaties: IReservatie[];
  userid: string;
  aantal: number = 10;

  constructor(private ResService : RestaurantService, private MsalService : MsalService, private analytics: GoogleAnalyticsService) {
    //Nog aanpassen nadat userid beschikbaar is
    if(MsalService.isLoggedIn())
      this.userid = MsalService.getUserObjectId();
   }

   SendEvent(buttonNaam: string) {
    this.analytics.eventEmitter("reservatieLijst", buttonNaam, buttonNaam, 1);
  }

  async ngOnInit() {
    this.ResService.GetReservationsByUserID(this.userid).subscribe(result => {
      this.reservaties = result;
    })
    this.reservaties = this.reservaties
  }

  isUserLoggedIn(){
    return this.MsalService.isLoggedIn();
  }

  Annuleer(reservatieId){
    this.ResService.DeleteReservationByID(reservatieId).subscribe(a => {
      this.ResService.GetReservationsByUserID(this.userid).subscribe(result => {
        this.reservaties = result;
      })
    });
    this.SendEvent("Verwijderen reservatie");
  }

  isEmpty(arr){
    if (!(arr.length > 0)){return true;}
    else{return false;}
  }

  showMore(){
    this.aantal += 10;
  }

}
