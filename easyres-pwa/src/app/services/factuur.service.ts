import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IGebruiker, IRestaurant } from './restaurant.service';
import { IProduct } from './bestelling.service';

@Injectable({
  providedIn: 'root'
})
export class FactuurService {

  urlAPI: string = 'https://easyres-api.azurewebsites.net/api';
  //urlAPI: string = "https://localhost:44315/api";

  constructor(private http: HttpClient) { }

  GenerateFactuur(userId: string, resId : number){
    return this.http.post<IFactuur>(`${this.urlAPI}/factuur/${userId}/${resId}`,"");
  }
  GetFactuur(userId: string, resId : number){
    return this.http.get<IFactuur>(`${this.urlAPI}/factuur/${userId}/${resId}`);
  }

}
export interface IFactuur {
  id: number;
  producten: IProduct[];
  gebruiker: IGebruiker;
  restaurant: IRestaurant;
  betaald: boolean;
  totaalPrijs: number;
  datum: Date;
}