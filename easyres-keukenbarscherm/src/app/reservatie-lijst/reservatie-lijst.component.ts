import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../services/restaurant.service';
import { MsalService } from '../services/msal.service';
import { IReservatie } from '../services/common.service';
import { IUitbater, UserService } from '../services/user.service';

@Component({
  selector: 'app-reservatie-lijst',
  templateUrl: './reservatie-lijst.component.html',
  styleUrls: ['./reservatie-lijst.component.scss']
})
export class ReservatieLijstComponent implements OnInit {

  reservaties: IReservatie[] = [];
  uitbater: IUitbater;
  aantal: number = 10;

  reservatiesLoading: boolean = true;
  reservatiesFailed: boolean = false;

  constructor(private ResService: RestaurantService, private msalService: MsalService, private userService: UserService) { }

  async ngOnInit() {
    if (this.msalService.isLoggedIn()) {
      this.msalService.isUitbater();
      this.userService.isuitbater(this.msalService.getUserObjectId()).subscribe(res =>{
        this.uitbater = res;
        this.GetReservationsByRestaurantID();
      });
    }
  }

  GetReservationsByRestaurantID() {
    this.reservatiesLoading = true;
    this.reservatiesFailed = false;
    this.ResService.GetReservationsByRestaurantID(this.uitbater.restaurantId).subscribe(res => {
      if (res != null) {
        this.reservaties = res;
      }
    },
    err => {
      this.reservatiesFailed = true;
      this.reservatiesLoading = false;
    },
    () => {
      this.reservatiesLoading = false;
    });
  }

  isUserLoggedIn() {
    return this.msalService.isLoggedIn();
  }

  Annuleer(reservatieId) {
    this.ResService.DeleteReservationByIDasUitbater(reservatieId).subscribe(a => {
      this.ResService.GetReservationsByRestaurantID(this.uitbater.restaurantId).subscribe(result => {
        this.reservaties = result;
      });
    });
  }

  isEmpty(arr) {
    if (!(arr.length > 0)) {
      return true;
    } else {
      return false;
    }
  }

  showMore() {
    this.aantal += 10;
  }

}
