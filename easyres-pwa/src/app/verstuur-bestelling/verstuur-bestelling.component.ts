import { Component, OnInit } from '@angular/core';
import { BestellingService, IBestelling } from '../services/bestelling.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-verstuur-bestelling',
  templateUrl: './verstuur-bestelling.component.html',
  styleUrls: ['./verstuur-bestelling.component.scss']
})
export class VerstuurBestellingComponent implements OnInit {

  TafelNr : number;
  RestaurantId : number;
  bestelling : IBestelling;
  constructor(private route: ActivatedRoute, private bestelServ :BestellingService) { 
    this.TafelNr = Number(this.route.snapshot.paramMap.get('TafelNr'));
    this.RestaurantId = Number(this.route.snapshot.paramMap.get('id'));
    this.bestelling = this.bestelServ.Bestelling;
  }
  
  ngOnInit() {
    this.bestelServ.PostOrder().subscribe(res => {
      console.log(res);
    });
  }

}
