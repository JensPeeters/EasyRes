import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http : HttpClient) { }

  url = "";

  GetAlleDrankbestellingen(){
    return this.http.get<IBestelling[]>(`https://localhost:44315/api/restaurant/1/bestelling/bar`);
  }

  GetAlleVoedingsbestellingen(){
    return this.http.get<IBestelling[]>(`https://localhost:44315/api/restaurant/1/bestelling/keuken`);
  }

  PutVoedingsbestelling(bestelling : IBestelling){
    return this.http.put<IBestelling>(`https://localhost:44315/api/restaurant/1/bestelling`, bestelling);
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