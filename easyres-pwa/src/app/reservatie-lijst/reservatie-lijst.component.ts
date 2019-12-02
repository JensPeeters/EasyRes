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

  FilterOp: string = 'Komende Reservaties';
  filterKeuzes: string[] = ['Komende Reservaties', 'Voorbije Reservaties'];

  constructor(private resService: RestaurantService, private msalService: MsalService, private analytics: GoogleAnalyticsService) {
    if (msalService.isLoggedIn()) {
      this.userid = msalService.getUserObjectId();
    }
   }

  SendEvent(buttonNaam: string) {
    this.analytics.eventEmitter('reservatieLijst', buttonNaam, buttonNaam, 1);
  }

  Filteren(item) {
    this.FilterOp = item;
    this.getReservations();
    this.SendEvent('Filteren op: ' + this.FilterOp);
  }

  async ngOnInit() {
    this.getReservations();
  }

  getReservations() {
    if (this.FilterOp === 'Komende Reservaties') {
      this.resService.GetReservationsByUserID(this.userid).subscribe(result => {
        this.reservaties = result;
      });
    } else if (this.FilterOp === 'Voorbije Reservaties') {
      this.resService.GetPastReservationsByUserID(this.userid).subscribe(result => {
        this.reservaties = result;
      });
    }
  }

  isUserLoggedIn() {
    return this.msalService.isLoggedIn();
  }

  Annuleer(reservatieId) {
    this.resService.DeleteReservationByID(reservatieId).subscribe(a => {
      this.resService.GetReservationsByUserID(this.userid).subscribe(result => {
        this.reservaties = result;
      });
    });
    this.SendEvent('Verwijderen reservatie');
  }

  isEmpty(arr) {
    if (!(arr.length > 0)) { return true; } else { return false; }
  }

  showMore() {
    this.aantal += 10;
  }

}
