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
  restaurant: IRestaurant;
  collapsed: boolean = false;
  inputRestaurantID: number;

  // Google Maps Variables
  locatie: string;
  results: any[];
  latitude: number;
  longitude: number;
  zoom = 18;
  mapType = 'roadmap';

  constructor(private ResService: RestaurantService,  private route: ActivatedRoute, private _location: Location, private analytics: GoogleAnalyticsService) { }

  SendEvent(buttonNaam: string) {
    this.analytics.eventEmitter("restaurantInfo", buttonNaam, buttonNaam, 1);
  }

  async ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.inputRestaurantID = Number(params.get('restaurant.restaurantId'));
    });
    if (this.inputRestaurantID != null) {
      this.ResService.GetRestaurantByID(this.inputRestaurantID).subscribe(result => {
        this.restaurant = result;
        this.locatie = `${this.restaurant.locatie.straat}+${this.restaurant.locatie.straatnummer},+${this.restaurant.locatie.postcode}+${this.restaurant.locatie.gemeente},+${this.restaurant.locatie.land}`;
        //Google Maps get
        this.ResService.GetLocatieVoorMap(this.locatie).subscribe(res => {
          this.results = res['results'];
          this.latitude = this.results[0].geometry.location.lat;
          this.longitude = this.results[0].geometry.location.lng;
        })
      });
    }
  }
  goBack() {
    this._location.back();
    this.SendEvent("Terug naar restaurantLijst");
  }
}
