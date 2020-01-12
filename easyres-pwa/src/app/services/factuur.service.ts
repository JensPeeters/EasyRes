import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService, IFactuur } from './common.service';

@Injectable({
  providedIn: 'root'
})
export class FactuurService {

  constructor(private http: HttpClient, private common: CommonService) { }

  GenerateFactuur(userId: string, resId: number, mail: string) {
    return this.http.post<IFactuur>(`${this.common.urlAPI}/factuur/${userId}/${resId}/${mail}`, '');
  }
  GetFactuur(userId: string, resId: number) {
    return this.http.get<IFactuur>(`${this.common.urlAPI}/factuur/${userId}/${resId}`);
  }

  GetFacturen(userId: string, sortby: string) {
    return this.http.get<IFactuur[]>(`${this.common.urlAPI}/factuur/${userId}?sortBy=${sortby}`);
  }

  GetFactuurById(factId: number) {
    return this.http.get<IFactuur>(`${this.common.urlAPI}/factuur/id/${factId}`);
  }
  UpdateFactuur(factuur: IFactuur){
    var updateFactuur = {id:factuur.id, betaald:factuur.betaald}
    return this.http.put<IFactuur>(`${this.common.urlAPI}/factuur`,updateFactuur);
  }
}
