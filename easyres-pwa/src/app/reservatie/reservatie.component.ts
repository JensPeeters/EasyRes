import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../services/restaurant.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { MsalService } from '../services/msal.service';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { IReservatie } from '../services/common.service';

@Component({
  selector: 'app-reservatie',
  templateUrl: './reservatie.component.html',
  styleUrls: ['./reservatie.component.scss']
})
export class ReservatieComponent implements OnInit {

  restaurantId: number;

  tempReservatie: IReservatie =
    {
      userid: null,
      naam: null,
      datum: null,
      email: null,
      telefoonnummer: null,
      tijdstip: null,
      aantalpersonen: null,
      restaurant: null
    };
  finalReservatie: IReservatie =
    {
      userid: null,
      naam: null,
      datum: null,
      email: null,
      telefoonnummer: null,
      tijdstip: null,
      aantalpersonen: null,
      restaurant: null
    };
  submitted: boolean = false;
  bezet: boolean = false;
  verified: boolean = false;
  today: Date = new Date();

  constructor(private ResService: RestaurantService, private MsalService: MsalService,
    private _Activatedroute: ActivatedRoute, private _location: Location, private analytics: GoogleAnalyticsService) {
    this.today.setTime(Date.now());

  }

  SendEvent(buttonNaam: string) {
    this.analytics.eventEmitter("reservatie", buttonNaam, buttonNaam, 1);
  }

  async ngOnInit() {
    this._Activatedroute.paramMap.subscribe(params => {
      this.restaurantId = +params.get('id');
    });

    if (this.restaurantId != null) {
      this.ResService.GetRestaurantByID(this.restaurantId).subscribe(result => {
        this.tempReservatie.restaurant = result;
      });
    }

    if (this.MsalService.isLoggedIn()) {
      this.tempReservatie.naam = this.MsalService.getUserFirstName() + ' ' + this.MsalService.getUserFamilyName();
      this.tempReservatie.email = this.MsalService.getUserEmail();
    }
  }

  submit() {
    this.finalReservatie = this.tempReservatie;
    if (this.inTime(this.finalReservatie)) {
      this.finalReservatie.userid = this.MsalService.getUserObjectId();
      this.ResService.PostReservation(this.finalReservatie).subscribe(
        a => {

          this.submitted = true;
          this.bezet = false;
          console.log("mail");


        },
        err => {
          this.submitted = false;
          console.log("bezet");
          this.bezet = true;
        });
    }
    this.SendEvent("Aanmaken Reservatie");
  }

  dayOfRes(dayOfWeek) {
    switch (dayOfWeek) {
      case 0: { return this.finalReservatie.restaurant.openingsuren.zondag; }
      case 1: { return this.finalReservatie.restaurant.openingsuren.maandag; }
      case 2: { return this.finalReservatie.restaurant.openingsuren.dinsdag; }
      case 3: { return this.finalReservatie.restaurant.openingsuren.woensdag; }
      case 4: { return this.finalReservatie.restaurant.openingsuren.donderdag; }
      case 5: { return this.finalReservatie.restaurant.openingsuren.vrijdag; }
      case 6: { return this.finalReservatie.restaurant.openingsuren.zaterdag; }
    }
  }

  inTime(res) {
    var givenDate = res.datum;
    givenDate = new Date(givenDate);
    var givenTime = res.tijdstip;
    var givenTimeSplit = givenTime.split(':');
    var restHrs = this.dayOfRes(givenDate.getDay());
    var restHrsSplit = restHrs.split(' ');
    var restOpen = restHrsSplit[0];
    var restOpenSplit = restOpen.split(':');
    var restClosed = restHrsSplit[2];
    var restClosedSplit = restClosed.split(':');

    // Genereert een Date object van de reservatie.
    var resDate = new Date(givenDate.getFullYear(), givenDate.getMonth(), givenDate.getDate(), givenTimeSplit[0], givenTimeSplit[1]);
    // Genereert een Date object vanaf wanneer het restaurant open is.
    var restOpenDate = new Date(givenDate.getFullYear(), givenDate.getMonth(), givenDate.getDate(), +restOpenSplit[0], +restOpenSplit[1]);
    // Genereert een Date object vanaf wanneer het restaurant gesloten is.
    var restClosedDate = new Date(givenDate.getFullYear(), givenDate.getMonth(), givenDate.getDate(), +restClosedSplit[0], +restClosedSplit[1]);

    if (resDate > restOpenDate && resDate < restClosedDate && res.aantalpersonen > 0) {
      return true;
    } else {
      return false;
    }
  }

  GoBack() {
    this._location.back();
    this.SendEvent("Terug naar restaurantLijst");
  }
}
