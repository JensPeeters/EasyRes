import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../services/restaurant.service';
import { MsalService } from '../services/msal.service';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { IRestaurant } from '../services/common.service';
import { FilterService, filters, type } from '../services/filter.service';


@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.scss']
})
export class RestaurantComponent implements OnInit {

  Restaurants : IRestaurant[];
  Advertentie : IRestaurant;
  
  
  constructor(private ResService : RestaurantService, private msalService: MsalService, private analytics: GoogleAnalyticsService,
              private filterService: FilterService) { }

  SendEvent(buttonNaam: string) {
    this.analytics.eventEmitter("restaurantLijst", buttonNaam, buttonNaam, 1);
  }

  zoeknaam: string;
  zoekterm: string;
  sorteerKeuzes: string[] = ["Aanbevolen","Naam","Type","Soort","Gemeente","Land"];
  UserId: string;

  landen: string[] = ["België","Nederland"];
  GemeentesBelgie: string[] = ["Sint-Niklaas","Antwerpen","Sint-Gillis-Waas"];
  GemeentesNederland: string[] = ["Amsterdam","Rotterdam","Den Haag","Groningen"];
  
  async ngOnInit() {
    if(this.isUserLoggedIn()){
      this.GetUserObjectId();
    }
    await this.GetRestaurants();
  }

  GetAdvertisement(){
    for(var element of this.Types){
      if (element.active) {
        this.ResService.GetAdvertisement(`${element.naam}`).subscribe( res => {
          this.Advertentie = res;
        });
        break;
      }
    }
  }

  Zoeken(){
    this.zoekterm = `naam=${this.zoeknaam}`;
    this.GetRestaurants();
    this.SendEvent("Zoeken: " + this.zoekterm);
  }
  Sorteren(item){
    this.SorterenOp = item;
    this.ResService.sortBy = item;
    if(this.zoeknaam != null && this.zoeknaam != "")
      this.Zoeken();
    else
      this.GetRestaurants();
    this.SendEvent("Sorteren op: " + this.SorterenOp);
  }
  async GetRestaurants(){
    var temp: IRestaurant[] = [];
    for(var element of this.Types){
      if (element.active) {
        var tempRestaurants = await this.ResService.GetRestaurants(`${this.zoekterm}&soort=${element.naam}&${this.filterService.filter}&${this.filterService.gerechtenOn}`);
        tempRestaurants.forEach(element => {
          temp.push(element);
        });
      }
    }
    this.GetAdvertisement();
    this.Restaurants = temp;
    if(this.isUserLoggedIn()){
      await this.CheckFavorites();
    }
  }
  ChangeTypes(type){
    type.active = !type.active;
    this.GetRestaurants();
    this.SendEvent("Aanpassen types");
  }
  ChangeGerechten(gerecht){
    gerecht.active = !gerecht.active;
    this.filterService.gerechtenOn = "";
    for(var element of this.Gerechten){
      if (element.active) {
        if(this.filterService.gerechtenOn == "")
          this.filterService.gerechtenOn += "gerechten=" + element.naam;
        else
        this.filterService.gerechtenOn += "," + element.naam;
      }
    }
    this.GetRestaurants();
    this.SendEvent("Aanpassen gerechten");
  }
  ChangeFilter(filter){
    filter.active = !filter.active;
  }
  async ApplyFilters(){
    this.filterService.filter = "";
    for(var element of this.Filters){
      if (element.active && element.value != "") {
        this.filterService.filter += `&${element.naam.toLowerCase()}=${element.value}`
      }
    }
    await this.GetRestaurants();
    this.SendEvent("Sorteren op locatie: " + this.Filters[0].value + ", " + this.Filters[1].value);
  }
  ChangeLocation(filterGiven:filters){
    if(filterGiven.naam == "Land"){
      return this.landen;
    }
    else if(filterGiven.naam == "Gemeente"){
      if(this.Filters[0].value == "België"){
        return this.GemeentesBelgie;
      }
      else if (this.Filters[0].value == "Nederland"){
        return this.GemeentesNederland;
      }
    }
    return [""];
  }
  isUserLoggedIn() {
    return this.msalService.isLoggedIn();
  }
  GetUserObjectId(){
    this.UserId = this.msalService.getUserObjectId();
  }
  AddDeleteFavorites(Restaurantid: number, index){
    if(this.RestaurantsFavoriteBooleans[index]){
      this.ResService.DeleteFavoritesByID(this.UserId, Restaurantid).subscribe();
      this.SendEvent("Verwijderen uit favorieten: " + Restaurantid);
    }
    else{
      this.ResService.PostFavorite(this.UserId,Restaurantid).subscribe();
      this.SendEvent("Toevoegen aan favorieten: " + Restaurantid);
    }
    this.RestaurantsFavoriteBooleans[index] = !this.RestaurantsFavoriteBooleans[index];
  }
  FavoriteRestaurants: IRestaurant[] = []
  async GetUserFavorites(){
    var tempGebruiker = await this.ResService.GetFavorites(this.UserId,"");
    this.FavoriteRestaurants = tempGebruiker.favorieten;
  }
  RestaurantsFavoriteBooleans: boolean[] = [];
  async CheckFavorites(){
    await this.GetUserFavorites();
    this.RestaurantsFavoriteBooleans = [];
    this.Restaurants.forEach(element => {
      if(this.FavoriteRestaurants.find(x => x.restaurantId === element.restaurantId))
        this.RestaurantsFavoriteBooleans.push(true);
      else
      this.RestaurantsFavoriteBooleans.push(false);
    });
  }
  async ngDoCheck() 
  {
    if(this.UserId == null && this.isUserLoggedIn()){
        this.GetUserObjectId();
        await this.CheckFavorites();
    }
  }


  get Types() {
    return this.filterService.types;
  }
  get Gerechten() {
    return this.filterService.gerechten;
  }
  get Filters(){
    return this.filterService.filters;
  }
  get SorterenOp(){
    return this.filterService.sorterenOp;
  }
  set SorterenOp(sorterenOp){
    this.filterService.sorterenOp = sorterenOp;
  }
}
