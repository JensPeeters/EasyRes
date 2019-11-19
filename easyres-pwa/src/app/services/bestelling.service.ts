import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService, IBestelling } from './common.service';

@Injectable({
  providedIn: 'root'
})
export class BestellingService {
  bestelling = {
    prijs: 0,
    tafelNr: 0,
    dranken: [],
    etenswaren: []
  };

  constructor(private http: HttpClient, private common: CommonService) { }

  PostOrder(UserId: string, ResId : number) {
    this.bestelling = this.Bestelling;
    return this.http.post<IBestelling>(`${this.common.urlAPI}/bestelling/restaurant/${ResId}/${UserId}`, this.bestelling);
  }
  GetOrdersForUser(UserId: string, RestaurantId: number) {
    return this.http.get<IBestelling[]>(`${this.common.urlAPI}/bestelling/gebruiker/${UserId}/${RestaurantId}`);
  }
  ClearBestelling(){
    this. bestelling = {
      prijs: 0,
      tafelNr: 0,
      dranken: [],
      etenswaren: []
    };
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
    return <IBestelling>this.bestelling;
  }
}