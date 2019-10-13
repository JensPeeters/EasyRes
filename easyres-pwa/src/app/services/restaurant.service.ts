import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  urlAPI : string = "https://localhost:44315/api";

  constructor(private http : HttpClient) { }

  GetRestaurants(){
    return this.http.get<IRestaurant[]>(`${this.urlAPI}/restaurant`);
  }
  GetRestaurantByID(id: number){
    return this.http.get<IRestaurant>(`${this.urlAPI}/restaurant/${id}`);
  }
}

export interface ILocatie {
  id: number;
  straat: string;
  gemeente: string;
  land: string;
  straatnummer: number;
  bus: string;
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