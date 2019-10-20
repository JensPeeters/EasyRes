import { Component, OnInit } from '@angular/core';
import { RestaurantService, IRestaurant } from '../services/restaurant.service';
import { ActivatedRoute } from '@angular/router';
import { NgForOf } from '@angular/common';
import { BestellingService, IProduct } from '../services/bestelling.service';

@Component({
  selector: 'app-bestel',
  templateUrl: './bestel.component.html',
  styleUrls: ['./bestel.component.scss']
})
export class BestelComponent implements OnInit {
  besteldProduct : IProduct;
  restaurant : IRestaurant;
  TafelNr : number ;
  buttons = [
    {
      type : "Dranken",
      nr : 1,
      state : false
    },
    {
      type : "Voorgerechten",
      nr : 2,
      state : false
    },
    {
      type : "Hoofdgerechten",
      nr : 3,
      state : false
    },
    {
      type : "Desserts",
      nr : 4,
      state : false
    },
  ];

  constructor(private resServ:RestaurantService, private route: ActivatedRoute,
    private bestelServ :BestellingService) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
      this.resServ.GetRestaurantByID(Number(id)).subscribe(restaurant => {
        this.restaurant = restaurant;
        this.bestelServ.Bestelling.restaurantId = Number(id);
      });
    this.bestelServ.bestelling.tafelNr = Number(this.route.snapshot.paramMap.get('TafelNr'));
    console.log(Number(this.route.snapshot.paramMap.get('TafelNr')));
    this.TafelNr = this.bestelServ.bestelling.tafelNr;
  }

  SendOrder(){
    this.bestelServ.PostOrder();
  }

  ChangeToFalse(state : boolean, buttonNumber : number){
    for(let button of this.buttons){
        if(buttonNumber == button.nr){
          button.state = !button.state;
        }
        else{
          button.state = false;
        }
    }
  }
  AddToKitchen(product : string, kost : number){
    this.besteldProduct = 
    {
      aantal : 1,
      naam : product,
      prijs : kost
    };
    if(this.bestelServ.bestelling.etenswaren.find(e => e.naam == this.besteldProduct.naam) != null){
      this.bestelServ.bestelling.etenswaren.find(e => e.naam == this.besteldProduct.naam).aantal++;
      console.log(this.bestelServ.bestelling.etenswaren);
    }else{
      this.bestelServ.bestelling.etenswaren.push(this.besteldProduct);
    }
  }
  AddToBar(product : string, kost : number){
    this.besteldProduct = 
    {
      aantal : 1,
      naam : product,
      prijs : kost
    };
    
    if(this.bestelServ.bestelling.dranken.find(e => e.naam == this.besteldProduct.naam) != null){
      this.bestelServ.bestelling.dranken.find(e => e.naam == this.besteldProduct.naam).aantal++;
      console.log(this.bestelServ.bestelling.dranken);
    }else{
      this.bestelServ.bestelling.dranken.push(this.besteldProduct);
    }
  }
}
