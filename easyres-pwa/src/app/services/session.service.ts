import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService, ISessie } from './common.service';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor(private http: HttpClient, private common: CommonService) { }

  CreateSession(RestaurantId: number, TafelNr: number, UserId: string){
    return this.http.post<ISessie>(`${this.common.urlAPI}/sessie/${UserId}/${RestaurantId}/${TafelNr}`, null);
  }
  GetSessions(UserId: string){
    return this.http.get<ISessie[]>(`${this.common.urlAPI}/sessie/${UserId}`);
  }
}