import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  urlAPI: string = 'https://easyres-api.azurewebsites.net/api';
  //urlAPI: string = "https://localhost:44315/api";

  constructor() { }
}

export interface IBestelling {
  prijs: number;
  tafelNr: number;
  restaurant: IRestaurant;
  dranken: IProduct[];
  etenswaren: IProduct[];
  bestellingId: number;
}

export interface IProduct {
  naam: string;
  prijs: number;
  aantal: number;
}

export interface IFactuur {
  id: number;
  producten: IProduct[];
  gebruiker: IGebruiker;
  restaurant: IRestaurant;
  betaald: boolean;
  totaalPrijs: number;
  datum: Date;
}
export interface IGebruiker {
  gebruikersID: string;
  favorieten: IRestaurant[];
}
export interface ILocatie {
  id: number;
  straat: string;
  gemeente: string;
  land: string;
  straatnummer: number;
  bus: string;
  postcode: number;
}

export interface IVoorgerechten {
  naam: string;
  prijs: number;
}

export interface IHoofdgerechten {
  naam: string;
  prijs: number;
}

export interface IDranken {
  naam: string;
  prijs: number;
}

export interface IDessert {
  naam: string;
  prijs: number;
}

export interface IMenu {
  id: number;
  voorgerechten: IVoorgerechten[];
  hoofdgerechten: IHoofdgerechten[];
  dranken: IDranken[];
  desserts: IDessert[];
}

export interface IOpeningsuren {
  id: number;
  maandag: string;
  dinsdag: string;
  woensdag: string;
  donderdag: string;
  vrijdag: string;
  zaterdag: string;
  zondag: string;
}

export interface ITafel {
  tafelId: number;
  tafelnr: number;
  zitplaatsen: number;
}

export interface IReservatie {
  userid: string;
  naam: string;
  email: string;
  telefoonnummer: string;
  datum: string;
  tijdstip: string;
  aantalpersonen: number;
  restaurant: IRestaurant;
}

export interface IRestaurant {
  restaurantId: number;
  naam: string;
  type: string;
  soort: string;
  locatie: ILocatie;
  menu: IMenu;
  tafels: ITafel[];
  openingsuren: IOpeningsuren;
  gerechten: string;
  korteBeschrijving: string;
  langeBeschrijving: string;
  logoImage: string;
  isAdvertentie: boolean;
}

export interface ISessie {
  id: number;
  gebruiker: IGebruiker;
  restaurant: IRestaurant;
  tafelNr: number;
}
