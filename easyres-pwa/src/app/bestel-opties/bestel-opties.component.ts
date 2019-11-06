import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-bestel-opties',
  templateUrl: './bestel-opties.component.html',
  styleUrls: ['./bestel-opties.component.scss']
})
export class BestelOptiesComponent implements OnInit {

  RestaurantId : number;
  TafelNr : number;
  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.RestaurantId = Number(this.route.snapshot.paramMap.get('id'));
    this.TafelNr = Number(this.route.snapshot.paramMap.get('TafelNr'));
  }

}
