import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IRestaurant } from '../restaurant/restaurant.component';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  urlAPI : string = "https://localhost:44315/api";

  constructor(private http : HttpClient) { }

  GetRestaurants(){
    return this.http.get<IRestaurant[]>(`${this.urlAPI}/restaurant`);
  }
}
