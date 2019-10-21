import { Component, OnInit } from '@angular/core';
import { RestaurantService, IReservatie, IRestaurant } from '../services/restaurant.service'
import { ActivatedRoute } from '@angular/router';
import {Location} from '@angular/common';

@Component({
  selector: 'app-reservatie',
  templateUrl: './reservatie.component.html',
  styleUrls: ['./reservatie.component.scss']
})
export class ReservatieComponent implements OnInit {

  restaurantId: number;

  tempReservatie: IReservatie = {naam:null,datum:null,email:null,nummer:null,tijdstip:null,aantal:null};
  finalReservatie: IReservatie;
  restaurant: IRestaurant;
  submitted: boolean = false;
  verified: boolean = false;
  today: Date;

  constructor(private ResService : RestaurantService, private _Activatedroute:ActivatedRoute, private _location: Location) { 
    this.today = new Date();
  }

  async ngOnInit() {
    this._Activatedroute.paramMap.subscribe(params => { 
      this.restaurantId = +params.get('id'); 
    });

    this.ResService.GetRestaurantByID(this.restaurantId).subscribe(result => {
      this.restaurant = result;
    })

  }

  submit() {
    this.finalReservatie = this.tempReservatie;
    if(this.verify(this.finalReservatie)){
      this.submitted = true;
    }
  }


  verify(res){
    if(this.today < this.strToDate(res.datum)){
      if(this.isInTime(res) && res.aantal > 0){
        return true;
      }
    }
    
  }
  //Controleert of dat de gereserveerde tijd een beschikbaar uur is van het restaurant
  isInTime(reservatie){
    var uren = this.stringSplitHHmm(this.dayOfRes(reservatie.datum));
    var open = uren[0];
    var gesloten = uren[1];
    if (this.stringToMinutes(open) < this.stringToMinutes(reservatie.tijdstip) && this.stringToMinutes(reservatie.tijdstip) < this.stringToMinutes(gesloten)){
      return true;
    }
    else{
      return false;
    }
  }
  
  stringSplitHHmm(str){
    //"16:00 - 20:00" => ["16:00","20:00"]
    var strsplit = str.split(" ");
    strsplit.splice(1,1);

    return strsplit;
  }

  stringToMinutes(str){
    var strsplit = str.split(":");
    return +strsplit[0] * 60 + +strsplit[1];
  }

  strToDate(date){
    return new Date(date);
  }

  dayOfRes(date){
    switch (this.strToDate(date).getDay()){
      case 1: { return this.restaurant.openingsuren.maandag}
      case 2: { return this.restaurant.openingsuren.dinsdag}
      case 3: { return this.restaurant.openingsuren.woensdag}
      case 4: { return this.restaurant.openingsuren.donderdag}
      case 5: { return this.restaurant.openingsuren.vrijdag}
      case 6: { return this.restaurant.openingsuren.zaterdag}
      case 7: { return this.restaurant.openingsuren.zondag}
    }
  }


  GoBack(){
    this._location.back();
  }
}
