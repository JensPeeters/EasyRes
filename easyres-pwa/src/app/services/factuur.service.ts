import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService, IFactuur } from './common.service';

@Injectable({
  providedIn: 'root'
})
export class FactuurService {

  constructor(private http: HttpClient, private common: CommonService) { }

  GenerateFactuur(userId: string, resId: number, mail: string) {
    return this.http.post<IFactuur>(`${this.common.urlAPI}/factuur/${userId}/${resId}?mail=${mail}`, '');
  }
  GetFactuur(userId: string, resId: number) {
    return this.http.get<IFactuur>(`${this.common.urlAPI}/factuur/${userId}/${resId}`);
  }

  GetFacturen(userId: string) {
    return this.http.get<IFactuur[]>(`${this.common.urlAPI}/factuur/${userId}`);
  }

  GetFactuurById(userId: string, factId: number) {
    return this.http.get<IFactuur>(`${this.common.urlAPI}/factuur/${userId}/factuur/${factId}`);
  }
}
