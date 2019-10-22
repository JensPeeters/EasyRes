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

  urlAPI: string = "https://localhost:44315/api";
  constructor(private http: HttpClient) { }

  PostOrder() {
    this.bestelling = this.Bestelling;
    console.log(this.bestelling.restaurantId)
    console.log(this.bestelling);
    console.log(this.Bestelling);
    return this.http.post(`${this.urlAPI}/restaurant/${this.bestelling.restaurantId}/bestelling`, this.bestelling)
  }

  get Bestelling(): IBestelling {
    let prijs = 0;
    for (let drank of this.bestelling.dranken) {
      prijs += drank.prijs * drank.aantal;
    }
    for (let etenswaar of this.bestelling.etenswaren) {
      prijs += etenswaar.prijs * etenswaar.aantal;
    }
    this.bestelling.prijs = prijs
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
  naam: string
  prijs: number
  aantal: number
}
