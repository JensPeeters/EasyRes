import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService, IReservatie, IRestaurant, IGebruiker } from './common.service';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  pageNumber: number = 0;
  pageSize: number = 25;
  sortBy: string = 'Aanbevolen';
  direction: string = 'asc';
  constructor(private http: HttpClient, private common: CommonService) { }

  // Restaurants
  GetRestaurants(filter?: string) {
    return this.http.get<IRestaurant[]>(`${this.common.urlAPI}/restaurant?${filter}&pageSize=${this.pageSize}&sortBy=${this.sortBy}&direction=${this.direction}&pageNumber=${this.pageNumber}`)
    .toPromise();
  }
  GetRestaurantByID(id: number) {
    if (id != 0) {
      return this.http.get<IRestaurant>(`${this.common.urlAPI}/restaurant/${id}`);
    }

  }

  // Favorieten
  GetFavorites(Gebruikersid: string, naam?: string) {
    return this.http.get<IGebruiker>(`${this.common.urlAPI}/favorieten/${Gebruikersid}?naam=${naam}`)
    .toPromise();
  }
  DeleteFavoritesByID(Gebruikersid: string, Restaurantid: number) {
    return this.http.delete(`${this.common.urlAPI}/favorieten/${Gebruikersid}/${Restaurantid}`);
  }
  PostFavorite(Gebruikersid: string, Restaurantid: number) {
    return this.http.post(`${this.common.urlAPI}/favorieten/${Gebruikersid}/${Restaurantid}`, null);
  }

  // Reservaties
  GetReservationsByUserID(userid: string) {
    return this.http.get<IReservatie[]>(`${this.common.urlAPI}/reservatie?userid=${userid}`);
  }

  GetReservationByID(id: number) {
    return this.http.get<IReservatie>(`${this.common.urlAPI}/reservatie/${id}`);
  }

  PostReservation(reservatie: IReservatie) {
    return this.http.post(`${this.common.urlAPI}/restaurant/${reservatie.restaurant.restaurantId}/reservatie`, reservatie);
  }

  DeleteReservationByID(id: number) {
    return this.http.delete(`${this.common.urlAPI}/reservatie/${id}`);
  }

  // Advertentie
  GetAdvertisement(soort: string){
    return this.http.get<IRestaurant>(`${this.common.urlAPI}/restaurant/advertentie/${soort}`);
  }

}