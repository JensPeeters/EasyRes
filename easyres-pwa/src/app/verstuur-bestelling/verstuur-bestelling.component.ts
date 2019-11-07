import { Component, OnInit } from '@angular/core';
import { BestellingService, IBestelling } from '../services/bestelling.service';
import { ActivatedRoute } from '@angular/router';
import { MsalService } from '../services/msal.service';

@Component({
  selector: 'app-verstuur-bestelling',
  templateUrl: './verstuur-bestelling.component.html',
  styleUrls: ['./verstuur-bestelling.component.scss']
})
export class VerstuurBestellingComponent implements OnInit {
  UserId: string;
  TafelNr: number;
  RestaurantId: number;
  bestelling: IBestelling;
  constructor(private route: ActivatedRoute, private bestelServ: BestellingService,
    private msalService: MsalService) {
    this.TafelNr = Number(this.route.snapshot.paramMap.get('TafelNr'));
    this.RestaurantId = Number(this.route.snapshot.paramMap.get('id'));

    if (this.msalService.isLoggedIn()) {
      this.GetUserObjectId();
    }
  }

  ngOnInit() {
    this.bestelServ.PostOrder(this.UserId, this.RestaurantId).subscribe(res => {
      this.bestelling = res;
    });
  }

  GetUserObjectId() {
    this.UserId = this.msalService.getUserObjectId();
  }

}
