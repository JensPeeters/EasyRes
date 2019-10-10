import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../services/restaurant.service';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})
export class RestaurantComponent implements OnInit {

  Restaurants : IRestaurant[];

  constructor(private ResService : RestaurantService) { }

  async ngOnInit() {
    this.ResService.GetRestaurants().subscribe(restaurants => {
      this.Restaurants = restaurants;
  })
  }
}

export interface ILocatie {
  id: number;
  straat: string;
  stad: string;
  land: string;
  straatnummer: number;
  bijvoegsel: string;
  postcode: number;
}

export interface IVoorgerechten {
  naam: string;
  prijs: number;
}

export interface IHoofdgerechten {
  naam: string;
  prijs: number;
}

export interface IDranken {
  naam: string;
  prijs: number;
}

export interface IDessert {
  naam: string;
  prijs: number;
}

export interface IMenu {
  id: number;
  voorgerechten: IVoorgerechten[];
  hoofdgerechten: IHoofdgerechten[];
  dranken: IDranken[];
  desserts: IDessert[];
}

export interface IOpeningsuren {
  id: number;
  maandag: string;
  dinsdag: string;
  woensdag: string;
  donderdag: string;
  vrijdag: string;
  zaterdag: string;
  zondag: string;
}

export interface IRestaurant {
  restaurantId: number;
  naam: string;
  type: string;
  locatie: ILocatie;
  menu: IMenu;
  openingsuren: IOpeningsuren;
  beschrijving: string;
  logoImage: string;
}