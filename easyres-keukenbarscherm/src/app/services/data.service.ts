import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IBestelling } from './common.service';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  url: string;

  constructor(private http: HttpClient) {
    this.url = "https://easyres-api.azurewebsites.net/api/bestelling/restaurant/2";
    //this.url = "https://localhost:44315/api/bestelling/restaurant/2";
   }

  GetAlleDrankbestellingen() {
    return this.http.get<IBestelling[]>(this.url+`/bar`);
  }

  GetAlleVoedingsbestellingen() {
    return this.http.get<IBestelling[]>(this.url+`/keuken`);
  }

  Putbestelling(bestelling: IBestelling) {
    return this.http.put<IBestelling>(this.url, bestelling);
  }
}