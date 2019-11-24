import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService, IGebruiker } from './common.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private common: CommonService) { }

  saveUserInDb(UserId) {
    return this.http.post(`${this.common.urlAPI}/user/gebruiker/${UserId}`, null);
  }
  updateGebruiker(gebruiker: IGebruiker, userId: string){
    return this.http.put(`${this.common.urlAPI}/user/${userId}`, gebruiker);
  }
  GetGerbuiker(userId: string){
    return this.http.get<IGebruiker>(`${this.common.urlAPI}/user/isgebruiker/${userId}`);
  }
}
