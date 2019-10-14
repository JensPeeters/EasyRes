import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import { RestaurantService, Reservatie, IRestaurant } from '../services/restaurant.service'
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-reservatie',
  templateUrl: './reservatie.component.html',
  styleUrls: ['./reservatie.component.scss']
})
export class ReservatieComponent implements OnInit {

  restaurantId: number;

  tempReservatie: Reservatie;
  finalReservatie: Reservatie;
  restaurant: IRestaurant;
  submitted: boolean = false;

  constructor(private ResService : RestaurantService, private _Activatedroute:ActivatedRoute) { 
    this.tempReservatie = new Reservatie();
    this.finalReservatie = new Reservatie();
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
    this.finalReservatie = this.tempReservatie
    this.submitted = true;
  }
}
