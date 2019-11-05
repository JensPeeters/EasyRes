import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BestellingService {
  bestelling: IBestelling = {
    prijs: 0,
    tafelNr: 0,
    restaurantId: 0,
    dranken: [],
    etenswaren: []
  };

  //urlAPI: string = 'https://easyres-api.azurewebsites.net/api';
  urlAPI : string = "https://localhost:44315/api";
  constructor(private http: HttpClient) { }

  PostOrder() {
    this.bestelling = this.Bestelling;
    return this.http.post(`${this.urlAPI}/bestelling/restaurant/${this.bestelling.restaurantId}`, this.bestelling);
  }
  GetOrdersForUser(UserId:string){
    return this.http.get<IBestelling[]>(`${this.urlAPI}/bestelling/gebruiker/${UserId}`);
  }

  get Bestelling(): IBestelling {
    let prijs = 0;
    for (let drank of this.bestelling.dranken) {
      prijs += drank.prijs * drank.aantal;
    }
    for (let etenswaar of this.bestelling.etenswaren) {
      prijs += etenswaar.prijs * etenswaar.aantal;
    }
    this.bestelling.prijs = prijs;
    return this.bestelling;
  }
}

export interface IBestelling {
  prijs: number;
  tafelNr: number;
  restaurantId: number;
  dranken: IProduct[];
  etenswaren: IProduct[];
}

export interface IProduct {
  naam: string;
  prijs: number;
  aantal: number;
}
