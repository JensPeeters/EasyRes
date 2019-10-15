import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http : HttpClient) { }

  GetAlleDrankbestellingen(){
    return this.http.get<IProduct>(`http://localhost/api/bestelling/drank`)
  }

  GetAlleVoedingsbestellingen(){
    return this.http.get<IProduct>(`http://localhost/api/bestelling/etenswaren`)
  }
}

export interface IProduct {
  ProductID
  Naam: string;
  Prijs: string;
}