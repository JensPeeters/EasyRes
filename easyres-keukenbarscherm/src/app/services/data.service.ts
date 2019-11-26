import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IBestelling } from './common.service';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  url: string;

  constructor(private http: HttpClient) {
    this.url = "https://easyres-api.azurewebsites.net/api";
    //this.url = "https://localhost:44315/api";
   }

  GetAlleDrankbestellingen(restaurantId: number) {
    return this.http.get<IBestelling[]>(`${this.url}/bestelling/restaurant/${restaurantId}/bar`);
  }

  GetAlleVoedingsbestellingen(restaurantId: number) {
    return this.http.get<IBestelling[]>(`${this.url}/bestelling/restaurant/${restaurantId}/keuken`);
  }

  Putbestelling(bestelling: IBestelling, restaurantId: number) {
    return this.http.put<IBestelling>(`${this.url}/bestelling/restaurant/${restaurantId}`, bestelling);
  }
}