import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  urlAPI: string = 'https://easyres-api.azurewebsites.net/api';
  //urlAPI : string = 'https://localhost:44315/api';

  constructor(private http: HttpClient) { }

  CreateSession(RestaurantId: number, TafelNr: number, UserId: string){
    return this.http.post<ISessie>(`${this.urlAPI}/sessie/${UserId}/${RestaurantId}/${TafelNr}`, null);
  }
  GetSessions(UserId: string){
    return this.http.get<ISessie[]>(`${this.urlAPI}/sessie/${UserId}`);
  }
}

export interface IGebruiker {
  gebruikersID: string;
  restaurants?: any;
}

export interface IRestaurant {
  restaurantId: number;
  naam: string;
  locatie?: any;
  menu?: any;
  openingsuren?: any;
  beschrijving: string;
  logoImage: string;
  type: string;
  soort: string;
}

export interface ISessie {
  id: number;
  gebruiker: IGebruiker;
  restaurant: IRestaurant;
  tafelNr: number;
}
