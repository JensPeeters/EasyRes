import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http : HttpClient) { }

  GetAlleDrankbestellingen(){
    return this.http.get<IBestelling[]>(`https://localhost:44315/api/restaurant/1/bestelling/bar`)
  }

  GetAlleVoedingsbestellingen(){
    return this.http.get<IBestelling[]>(`https://localhost:44315/api/restaurant/1/bestelling/keuken`)
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
      besteldeEtenswaren: IProduct[];
      besteldeDranken: IProduct[];
      tafelNr: number;
      Etengereed: boolean;
      Drinkengereed: boolean;
  }