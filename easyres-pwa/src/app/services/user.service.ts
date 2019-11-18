import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService } from './common.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private common: CommonService) { }

  saveUserInDb(UserId) {
    return this.http.post(`${this.common.urlAPI}/user/gebruiker/${UserId}`, null);
  }
}
