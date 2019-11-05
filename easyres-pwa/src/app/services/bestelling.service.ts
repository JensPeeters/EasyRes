import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IRestaurant } from './restaurant.service';

@Injectable({
  providedIn: 'root'
})
export class BestellingService {
  bestelling = {
    prijs: 0,
    tafelNr: 0,
    dranken: [],
    etenswaren: []
  };

  //urlAPI: string = 'https://easyres-api.azurewebsites.net/api';
  urlAPI: string = "https://localhost:44315/api";
  constructor(private http: HttpClient) { }

  PostOrder(UserId: string, ResId : number) {
    this.bestelling = this.Bestelling;
    console.log(UserId);
    console.log(this.bestelling);
    return this.http.post(`${this.urlAPI}/bestelling/restaurant/${ResId}/${UserId}`, this.bestelling);
  }
  GetOrdersForUser(UserId: string, RestaurantId: number) {
    return this.http.get<IBestelling[]>(`${this.urlAPI}/bestelling/gebruiker/${UserId}/${RestaurantId}`);
  }

  get Bestelling(): IBestelling {
    let prijs = 0;
    for (let drank of this.bestelling.dranken) {
      prijs += drank.prijs * drank.aantal;
    }
    for (let etenswaar of this.bestelling.etenswaren) {
      prijs += etenswaar.prijs * etenswaar.aantal;
    }
    this.bestelling.prijs = prijs;
    return <IBestelling>this.bestelling;
  }
}

export interface IBestelling {
  prijs: number;
  tafelNr: number;
  restaurant: IRestaurant;
  dranken: IProduct[];
  etenswaren: IProduct[];
  bestellingId: number;
}
export interface IRestaurant {
  restaurantId: number;
  naam: string;
  locatie: any;
  menu: any;
  openingsuren: any;
  beschrijving: string;
  logoImage: string;
  type: string;
  soort: string;
}

export interface IProduct {
  naam: string;
  prijs: number;
  aantal: number;
}
