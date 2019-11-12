import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  //urlAPI = 'https://easyres-api.azurewebsites.net/api';
  urlAPI = 'https://localhost:44315/api';

  saveUserInDb(UserId) {
    return this.http.post(`${this.urlAPI}/user/gebruiker/${UserId}`, null);
  }
}
