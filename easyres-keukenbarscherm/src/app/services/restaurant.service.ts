import { Injectable } from '@angular/core';
import { IRestaurant, CommonService } from './common.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  constructor(private http: HttpClient, private common: CommonService) { }

  GetRestaurantByID(id: number) {
    if (id != 0) {
      return this.http.get<IRestaurant>(`${this.common.urlAPI}/restaurant/${id}`);
    }
  }
  PutRestaurant(restaurant: IRestaurant) {
    // Id's verwijderen zodat de put in de backend werkt :)
    delete restaurant.menu.id;
    //for (var i = 0; i < restaurant.tafels.length; i++){
    //  delete restaurant.tafels[i].tafelID;
    //}
    return this.http.put<IRestaurant>(`${this.common.urlAPI}/restaurant/${restaurant.restaurantId}`, restaurant);
  }
}
