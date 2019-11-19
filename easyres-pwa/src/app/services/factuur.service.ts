import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService, IFactuur } from './common.service';

@Injectable({
  providedIn: 'root'
})
export class FactuurService {

  constructor(private http: HttpClient, private common: CommonService) { }

  GenerateFactuur(userId: string, resId: number) {
    return this.http.post<IFactuur>(`${this.common.urlAPI}/factuur/${userId}/${resId}`, '');
  }
  GetFactuur(userId: string, resId: number) {
    return this.http.get<IFactuur>(`${this.common.urlAPI}/factuur/${userId}/${resId}`);
  }

  GetFacturen(userId: string) {
    return this.http.get<IFactuur[]>(`${this.common.urlAPI}/factuur/${userId}`);
  }

}
