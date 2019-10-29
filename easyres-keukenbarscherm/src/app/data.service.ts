import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  GetAlleDrankbestellingen() {
    return this.http.get<IBestelling[]>(`https://easyres-api.azurewebsites.net/api/restaurant/1/bestelling/bar`);
  }

  GetAlleVoedingsbestellingen() {
    return this.http.get<IBestelling[]>(`https://easyres-api.azurewebsites.net/api/restaurant/1/bestelling/keuken`);
  }

  PutVoedingsbestelling(bestelling: IBestelling) {
    return this.http.put<IBestelling>(`https://easyres-api.azurewebsites.net/api/restaurant/1/bestelling`, bestelling);
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
  tafelNr: number;
  etenGereed: boolean;
  Drinkengereed: boolean;
  }
