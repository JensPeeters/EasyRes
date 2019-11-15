import { Component, OnInit } from '@angular/core';
import { MsalService } from '../services/msal.service';
import { BestellingService, IBestelling } from '../services/bestelling.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-bestellingen',
  templateUrl: './bestellingen.component.html',
  styleUrls: ['./bestellingen.component.scss']
})
export class BestellingenComponent implements OnInit {
  UserId : string;
  RestaurantId : number;
  Bestellingen : IBestelling[];
  TafelNr : number;
  collapsed: boolean = false;

  constructor(private msalService: MsalService, private bestelServ :BestellingService,
    private route: ActivatedRoute) { }

  bestellingLoading: boolean = true;

  ngOnInit() {

    if(this.msalService.isLoggedIn()){
      this.GetUserObjectId();
    }
    this.RestaurantId = Number(this.route.snapshot.paramMap.get('id'));
    this.TafelNr = Number(this.route.snapshot.paramMap.get('TafelNr'));
    this.bestelServ.GetOrdersForUser(this.UserId,this.RestaurantId).subscribe( res => {
      this.Bestellingen = res;
      this.bestellingLoading = false;
    });
  }
  GetUserObjectId(){
    this.UserId = this.msalService.getUserObjectId();
  }
  collapseBestellingen(){
    this.collapsed != this.collapsed;
  }

}
