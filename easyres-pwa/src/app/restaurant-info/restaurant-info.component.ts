import { Component, OnInit} from '@angular/core';
import { RestaurantService } from '../services/restaurant.service';
import { ActivatedRoute } from '@angular/router';
import {Location} from '@angular/common';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { IRestaurant } from '../services/common.service';


@Component({
  selector: 'app-restaurant-info',
  templateUrl: './restaurant-info.component.html',
  styleUrls: ['./restaurant-info.component.scss']
})
export class RestaurantInfoComponent implements OnInit {

  constructor(private ResService: RestaurantService,  private route: ActivatedRoute, private _location: Location, private analytics: GoogleAnalyticsService) { }

  SendEvent(buttonNaam: string) {
    this.analytics.eventEmitter("restaurantInfo", buttonNaam, buttonNaam, 1);
  }

  restaurant: IRestaurant;
  collapsed: boolean = false;
  inputRestaurantID: number;

  async ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.inputRestaurantID = Number(params.get('restaurant.restaurantId'));
    });
    if (this.inputRestaurantID != null) {
      this.ResService.GetRestaurantByID(this.inputRestaurantID).subscribe(result => {
        this.restaurant = result;
      });
    }
  }
  goBack() {
    this._location.back();
    this.SendEvent("Terug naar restaurantLijst");
  }
}
