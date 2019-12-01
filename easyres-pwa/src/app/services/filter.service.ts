import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  constructor() { }

  gerechtenOn: string = "";
  filter: string = "";
  sorterenOp: string = "Aanbevolen";

  types: type[] = [
    {naam: "Restaurant",active:true},
    {naam: "Taverne",active:true},
    {naam: "Bistro",active:true},
    {naam: "Trattoria",active:true}
  ];

  gerechten: type[] = [
    {naam: "Pizza",active:false},
    {naam: "Pasta",active:false},
    {naam: "Salade",active:false},
    {naam: "Stoverij",active:false}
  ];

  filters: filters[] = [
    {naam: "Land", value: "", active: false},
    {naam: "Gemeente", value: "", active: false}
  ];

}
export interface type{
  naam: string;
  active: boolean;
}
export interface filters{
  naam: string;
  value: string;
  active: boolean;
}