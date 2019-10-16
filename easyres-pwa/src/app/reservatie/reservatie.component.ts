import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import { RestaurantService, IReservatie, IRestaurant } from '../services/restaurant.service'
import { ActivatedRoute } from '@angular/router';

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

  constructor(private ResService : RestaurantService, private _Activatedroute:ActivatedRoute) { 
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
    this.verify(this.finalReservatie);
  }
  //Tijd is checked, datum na vandaag todo
  verify(res){
    //if(){
      if(this.isInTime(this.finalReservatie.tijdstip)){
        this.submitted = true;
      }
    //}
    
  }

  isInTime(reservatie){
    var uren = this.stringSplitHHmm(this.dayOfRes());
    var open = uren[0];
    var gesloten = uren[1];
    console.log(this.stringToMinutes(reservatie));
    if (this.stringToMinutes(open) < this.stringToMinutes(reservatie) && this.stringToMinutes(reservatie) < this.stringToMinutes(gesloten)){
      return true;
    }
    else{
      return false;
    }
  }
  
  stringSplitHHmm(str){
    var strsplit = str.split(" ");
    strsplit.splice(1,1);

    console.log(strsplit);
    return strsplit;
  }

  stringToMinutes(str){
    var strsplit = str.split(":");
    return +strsplit[0] * 60 + +strsplit[1];
  }

  dayOfWeek(date){
    return new Date(date).getDay();
  }

  dayOfRes(){
    switch (this.dayOfWeek(this.tempReservatie.datum)){
      case 1: { return this.restaurant.openingsuren.maandag}
      case 2: { return this.restaurant.openingsuren.dinsdag}
      case 3: { return this.restaurant.openingsuren.woensdag}
      case 4: { return this.restaurant.openingsuren.donderdag}
      case 5: { return this.restaurant.openingsuren.vrijdag}
      case 6: { return this.restaurant.openingsuren.zaterdag}
      case 7: { return this.restaurant.openingsuren.zondag}
    }
  }
}
