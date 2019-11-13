import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BestellingService, IBestelling } from '../services/bestelling.service';
import { MsalService } from '../services/msal.service';
import { RestaurantComponent } from '../restaurant/restaurant.component';
import { GoogleAnalyticsService } from '../services/google-analytics.service';

@Component({
  selector: 'app-bestelde-producten',
  templateUrl: './bestelde-producten.component.html',
  styleUrls: ['./bestelde-producten.component.scss']
})
export class BesteldeProductenComponent implements OnInit {
  TafelNr : number;
  RestaurantId : number;
  bestelling : IBestelling;
  UserId : string;

  constructor(private route: ActivatedRoute, private bestelServ :BestellingService,
    private msalService: MsalService, private analytics: GoogleAnalyticsService) { 
    this.TafelNr = Number(this.route.snapshot.paramMap.get('TafelNr'));
    this.RestaurantId = Number(this.route.snapshot.paramMap.get('id'));
    this.bestelling = this.bestelServ.Bestelling;
  }

  SendEvent(buttonNaam: string) {
    this.analytics.eventEmitter("Bestell", buttonNaam, buttonNaam, 1);
  }

  ngOnInit() {
    if(this.msalService.isLoggedIn()){
      this.GetUserObjectId();
    }
  }
  GetUserObjectId(){
    this.UserId = this.msalService.getUserObjectId();
  }

  VerwijderDrank(naam:string){
    this.bestelServ.Bestelling.dranken.forEach((drank, index) => {
      if(drank.naam == naam) this.bestelServ.bestelling.dranken.splice(index,1);
      this.bestelling = this.bestelServ.Bestelling;
    })
  }
  VerwijderEtenswaar(naam:string){
    this.bestelServ.Bestelling.etenswaren.forEach((etenswaar, index) => {
      if(etenswaar.naam == naam) this.bestelServ.bestelling.etenswaren.splice(index,1);
      this.bestelling = this.bestelServ.Bestelling;
    })
  }

  SendOrder(){
    this.bestelServ.PostOrder(this.UserId, this.RestaurantId);
  }

}
