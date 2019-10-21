import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  urlAPI : string = "https://localhost:44315/api";
  pageNumber: number = 0;
  pageSize: number = 25;
  sortBy: string = "Aanbevolen"
  direction: string = "asc"
  constructor(private http : HttpClient) { }

  GetRestaurants(filter?: string){
    return this.http.get<IRestaurant[]>(`${this.urlAPI}/restaurant?${filter}&pageSize=${this.pageSize}&sortBy=${this.sortBy}&direction=${this.direction}&pageNumber=${this.pageNumber}`);
  }
  GetRestaurantByID(id: number){
    return this.http.get<IRestaurant>(`${this.urlAPI}/restaurant/${id}`);
  }

  PostReservation(restaurant: IRestaurant, reservatie: IReservatie){
    console.log("Post request verzonden");
    return this.http.post(`${this.urlAPI}/restaurant/${restaurant.restaurantId}/reservatie`, {
      "naam": reservatie.naam,
      "email": reservatie.email,
      "telefoonNummer": reservatie.nummer,
      "datum": reservatie.datum,
      "tijdstip": reservatie.tijdstip,
      "aantalPersonen": reservatie.aantal,
      "restaurant": restaurant
    })
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

export interface IReservatie{
  naam: string;
  email: string;
  nummer: string;
  datum: string;
  tijdstip: string;
  aantal: number;
}

export interface IRestaurant {
  restaurantId: number;
  naam: string;
  type: string;
  soort: string;
  locatie: ILocatie;
  menu: IMenu;
  openingsuren: IOpeningsuren;
  beschrijving: string;
  logoImage: string;
}