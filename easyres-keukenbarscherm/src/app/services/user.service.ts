import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  urlAPI = 'https://easyres-api.azurewebsites.net/api';
  //urlAPI = 'https://localhost:44315/api';

  saveUserInDb(UserId) {
    return this.http.post(`${this.urlAPI}/user/uitbater/${UserId}`, null);
  }

  isuitbater(UserId) {
    return this.http.get<IUitbater>(`${this.urlAPI}/user/isuitbater/${UserId}`);
  }

  GetFacturenUitbater(resId : number){
    return this.http.get<IFactuur[]>(`${this.urlAPI}/factuur/restaurant/${resId}`);
  }
}

export interface IUitbater {
  gebruikersID: string;
  restaurantId: number;
}

export interface IFactuur {
  id: number;
  producten: IProduct[];
  gebruiker: IGebruiker;
  restaurant: IRestaurant;
  betaald: boolean;
  totaalPrijs: number;
  tafelNr: number;
  datum: Date;
}
export interface ITafel {
  tafelId: number;
  tafelnr: number;
  zitplaatsen: number;
}
export interface IRestaurant {
  restaurantId: number;
  naam: string;
  type: string;
  soort: string;
  locatie: any;
  menu: any;
  tafels: ITafel[];
  openingsuren: any;
  gerechten: string;
  korteBeschrijving: string;
  langeBeschrijving: string;
  logoImage: string;
  isAdvertentie: boolean;
}
export interface IGebruiker {
  gebruikersID: string;
  favorieten: IRestaurant[];
  getFactuurByEmail: boolean;
}
export interface IProduct {
  naam: string;
  prijs: number;
  aantal: number;
}
