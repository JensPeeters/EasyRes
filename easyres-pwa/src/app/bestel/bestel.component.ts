import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../services/restaurant.service';
import { ActivatedRoute } from '@angular/router';
import { BestellingService } from '../services/bestelling.service';
import { MsalService } from '../services/msal.service';
import { IRestaurant, IProduct, IVoorgerechten, IHoofdgerechten, IDranken, IDessert } from '../services/common.service';

@Component({
  selector: 'app-bestel',
  templateUrl: './bestel.component.html',
  styleUrls: ['./bestel.component.scss']
})
export class BestelComponent implements OnInit {
  restaurant: IRestaurant;

  ShownVoorgerechten: IVoorgerechten[];
  ShownHoofdgerechten: IHoofdgerechten[];
  ShownDranken: IDranken[];
  ShownDesserts: IDessert[];
  
  UserId: string;
  TafelNr: number;
  menuLoading: boolean = true;
  menuFailed: boolean = false;
  buttons = [
    {
      type: 'Dranken',
      nr: 1,
      state: false
    },
    {
      type: 'Voorgerechten',
      nr: 2,
      state: false
    },
    {
      type: 'Hoofdgerechten',
      nr: 3,
      state: false
    },
    {
      type: 'Desserts',
      nr: 4,
      state: false
    },
  ];

  searchEntry: string = "";

  constructor(private resServ: RestaurantService, private route: ActivatedRoute,
              private bestelServ: BestellingService, private msalService: MsalService) { }
  restuarantId;
  ngOnInit() {
    this.restuarantId = this.route.snapshot.paramMap.get('id');
    this.GetRestaurant();
    this.bestelServ.bestelling.tafelNr = Number(this.route.snapshot.paramMap.get('TafelNr'));
    this.TafelNr = this.bestelServ.bestelling.tafelNr;
    if (this.msalService.isLoggedIn()) {
      this.GetUserObjectId();
    }
  }
  GetRestaurant(){
    if (this.restuarantId != null) {
      this.menuFailed = false;
      this.menuLoading = true;
      this.resServ.GetRestaurantByID(Number(this.restuarantId)).subscribe(restaurant => {
        this.restaurant = restaurant;
        this.LoadBarProducts();
        this.LoadKitchenProducts();
        this.ShowMenu();
      },
      err => {
        this.menuFailed = true;
        this.menuLoading = false;
      },
      () => {
        this.menuLoading = false;
      });
    }
  }
  GetUserObjectId() {
    this.UserId = this.msalService.getUserObjectId();
  }

  SendOrder() {
    this.bestelServ.PostOrder(this.UserId, this.restaurant.restaurantId);
  }

  ChangeToFalse(state: boolean, buttonNumber: number) {
    for (let button of this.buttons) {
      if (buttonNumber == button.nr) {
        button.state = !button.state;
      } else {
        button.state = false;
      }
    }
  }
  AddToKitchen(product: IProduct) {
    if (this.bestelServ.bestelling.etenswaren.find(e => e.naam == product.naam) != null) {
      this.bestelServ.bestelling.etenswaren.find(e => e.naam == product.naam).aantal++;
    } else {
      var besteldProduct: IProduct = {
        aantal: 1,
        naam: product.naam,
        prijs: product.prijs
      };
      this.bestelServ.bestelling.etenswaren.push(besteldProduct);
    }
    this.UpdateKitchenProduct(product);
  }
  RemoveFromKitchen(product: IProduct){
    var tempEten = this.bestelServ.bestelling.etenswaren.find(e => e.naam == product.naam);
    if (tempEten != null) {
      if(tempEten.aantal <= 1){
        const index: number = this.bestelServ.bestelling.etenswaren.indexOf(tempEten);
        if(index != -1)
          this.bestelServ.bestelling.etenswaren.splice(index, 1);
      }
      else{
        this.bestelServ.bestelling.etenswaren.find(e => e.naam == tempEten.naam).aantal--;
      }   
    }
    this.UpdateKitchenProduct(product);
  }
  AddToBar(product: IProduct) {
    if (this.bestelServ.bestelling.dranken.find(e => e.naam == product.naam) != null) {
      this.bestelServ.bestelling.dranken.find(e => e.naam == product.naam).aantal++;
    } else {
      var besteldProduct: IProduct = {
        aantal: 1,
        naam: product.naam,
        prijs: product.prijs
      };
      this.bestelServ.bestelling.dranken.push(besteldProduct);
    }
    this.restaurant.menu.dranken.find(e => e.naam == product.naam).aantal++;
  }
  RemoveFromBar(product: IProduct){
    var tempDrinken = this.bestelServ.bestelling.dranken.find(e => e.naam == product.naam);
    if (tempDrinken != null) {
      if(tempDrinken.aantal <= 1){
        const index: number = this.bestelServ.bestelling.dranken.indexOf(tempDrinken);
        if(index != -1)
          this.bestelServ.bestelling.dranken.splice(index, 1);
      }
      else{
        this.bestelServ.bestelling.dranken.find(e => e.naam == tempDrinken.naam).aantal--;
      }   
      this.restaurant.menu.dranken.find(e => e.naam == product.naam).aantal--;
    }
  }
  UpdateKitchenProduct(product: IProduct){
    var tempProduct = this.bestelServ.bestelling.etenswaren.find(e => e.naam == product.naam);
    if(tempProduct != null){
      product.aantal = tempProduct.aantal;
    }
    else{
      product.aantal = 0;
    }
  }
  LoadBarProducts(){
    this.bestelServ.bestelling.dranken.forEach(element => {
      this.restaurant.menu.dranken.find(e => e.naam == element.naam).aantal = element.aantal;
    });
  }
  LoadKitchenProducts(){
    this.bestelServ.bestelling.etenswaren.forEach(element => {
      var tempProduct = this.restaurant.menu.voorgerechten.find(e => e.naam == element.naam);
      if(tempProduct == null)
        tempProduct = this.restaurant.menu.hoofdgerechten.find(e => e.naam == element.naam);
      if(tempProduct == null)
        tempProduct = this.restaurant.menu.desserts.find(e => e.naam == element.naam);
      if(tempProduct != null)
        tempProduct.aantal = element.aantal;
    });
  }
  ShowMenu(){
    this.ShownDranken = this.restaurant.menu.dranken;
    this.ShownVoorgerechten = this.restaurant.menu.voorgerechten;
    this.ShownHoofdgerechten = this.restaurant.menu.hoofdgerechten;
    this.ShownDesserts = this.restaurant.menu.desserts;
  }
  Search(){
    if(this.searchEntry == ""){
      this.ShowMenu();
    }
    else{
      var dranken = [];
      var voorgerechten = [];
      var hoofdgerechten = [];
      var desserts = [];
      this.restaurant.menu.dranken.map(product =>{
        if(product.naam.toLocaleLowerCase().indexOf(this.searchEntry.toLocaleLowerCase()) !== -1){
          dranken.push(product);
        }
      });
      this.restaurant.menu.voorgerechten.map(product =>{
        if(product.naam.toLocaleLowerCase().indexOf(this.searchEntry.toLocaleLowerCase()) !== -1){
          voorgerechten.push(product);
        }
      });
      this.restaurant.menu.hoofdgerechten.map(product =>{
        if(product.naam.toLocaleLowerCase().indexOf(this.searchEntry.toLocaleLowerCase()) !== -1){
          hoofdgerechten.push(product);
        }
      });
      this.restaurant.menu.desserts.map(product =>{
        if(product.naam.toLocaleLowerCase().indexOf(this.searchEntry.toLocaleLowerCase()) !== -1){
          desserts.push(product);
        }
      });

      this.ShownDranken = dranken;
      this.ShownVoorgerechten = voorgerechten;
      this.ShownHoofdgerechten = hoofdgerechten;
      this.ShownDesserts = desserts;
    }
  }
  get DrankenAmount(){
    return this.ShownDranken.length;
  }
  get VoorgerechtenAmount(){
    return this.ShownVoorgerechten.length;
  }
  get HoofdgerechtenAmount(){
    return this.ShownHoofdgerechten.length;
  }
  get DessertsAmount(){
    return this.ShownDesserts.length;
  }
}
