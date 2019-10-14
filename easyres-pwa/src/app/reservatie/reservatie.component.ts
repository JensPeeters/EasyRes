import { Component, OnInit } from '@angular/core';
import { Reservatie } from '../services/restaurant.service'

@Component({
  selector: 'app-reservatie',
  templateUrl: './reservatie.component.html',
  styleUrls: ['./reservatie.component.scss']
})
export class ReservatieComponent implements OnInit {

  tempReservatie: Reservatie;
  finalReservatie: Reservatie;

  constructor() { 
    this.tempReservatie = new Reservatie();
    this.finalReservatie = new Reservatie();
  }

  ngOnInit() {
  }

  submit() {
    this.finalReservatie = this.tempReservatie
  }
}
