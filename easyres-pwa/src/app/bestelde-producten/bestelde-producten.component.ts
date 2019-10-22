import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BestellingService, IBestelling } from '../services/bestelling.service';

@Component({
  selector: 'app-bestelde-producten',
  templateUrl: './bestelde-producten.component.html',
  styleUrls: ['./bestelde-producten.component.scss']
})
export class BesteldeProductenComponent implements OnInit {
  TafelNr : number;
  RestaurantId : number;
  bestelling : IBestelling;
  constructor(private route: ActivatedRoute, private bestelServ :BestellingService) { 
    this.TafelNr = Number(this.route.snapshot.paramMap.get('TafelNr'));
    this.RestaurantId = Number(this.route.snapshot.paramMap.get('id'));
    this.bestelling = this.bestelServ.Bestelling;
  }
  ngOnInit() {
  }

  SendOrder(){
    this.bestelServ.PostOrder();
  }

}
