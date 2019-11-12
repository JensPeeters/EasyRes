import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


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

export interface IProduct {
  productId: number;
  naam: string;
  prijs: number;
  aantal: number;
  }


export interface IBestelling {
  bestellingId: number;
  etenswaren: IProduct[];
  dranken: IProduct[];
  restaurantId: number;
  etenGereed: boolean;
  drinkenGereed: boolean;
  huidigeTijd: string;
  eetTijdKlaar: Date;
  drinkTijdKlaar: Date;
  tafelNr: number;
  }
 