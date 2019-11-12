import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  urlAPI: string = 'https://easyres-api.azurewebsites.net/api';
  //urlAPI : string = 'https://localhost:44315/api';
  pageNumber: number = 0;
  pageSize: number = 25;
  sortBy: string = 'Aanbevolen';
  direction: string = 'asc';
  constructor(private http: HttpClient) { }

  // Restaurants
  GetRestaurants(filter?: string) {
    return this.http.get<IRestaurant[]>(`${this.urlAPI}/restaurant?${filter}&pageSize=${this.pageSize}&sortBy=${this.sortBy}&direction=${this.direction}&pageNumber=${this.pageNumber}`)
    .toPromise();
  }
  GetRestaurantByID(id: number) {
    if (id != 0){
      return this.http.get<IRestaurant>(`${this.urlAPI}/restaurant/${id}`);
    }

  }

  // Favorieten
  GetFavorites(Gebruikersid: string, naam?: string){
    return this.http.get<IGebruiker>(`${this.urlAPI}/favorieten/${Gebruikersid}?naam=${naam}`)
    .toPromise();
  }
  DeleteFavoritesByID(Gebruikersid: string, Restaurantid: number){
    return this.http.delete(`${this.urlAPI}/favorieten/${Gebruikersid}/${Restaurantid}`);
  }
  PostFavorite(Gebruikersid: string, Restaurantid: number){ 
    return this.http.post(`${this.urlAPI}/favorieten/${Gebruikersid}/${Restaurantid}`, null);
  }

  // Reservaties
  GetReservationsByUserID(userid: string) {
    return this.http.get<IReservatie[]>(`${this.urlAPI}/reservatie?userid=${userid}`);
  }

  GetReservationByID(id: number) {
    return this.http.get<IReservatie>(`${this.urlAPI}/reservatie/${id}`);
  }

  PostReservation(reservatie: IReservatie) {
    return this.http.post(`${this.urlAPI}/restaurant/${reservatie.restaurant.restaurantId}/reservatie`, reservatie);
  }

  DeleteReservationByID(id: number) {
    return this.http.delete(`${this.urlAPI}/reservatie/${id}`);
  }
}
export interface IGebruiker {
  id: number;
  gebruikersID: string;
  restaurants: IRestaurant[];
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

export interface IReservatie {
  userid: string;
  naam: string;
  email: string;
  telefoonnummer: string;
  datum: string;
  tijdstip: string;
  aantalpersonen: number;
  restaurant: IRestaurant;
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
