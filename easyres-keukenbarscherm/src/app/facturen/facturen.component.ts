import { Component, OnInit } from '@angular/core';
import { UserService, IUitbater, IFactuur } from '../services/user.service';
import { MsalService } from '../services/msal.service';

@Component({
  selector: 'app-facturen',
  templateUrl: './facturen.component.html',
  styleUrls: ['./facturen.component.scss']
})
export class FacturenComponent implements OnInit {
  BetaaldeFacturenView: boolean = true;
  BetaaldeFacturen: IFactuur[] = [];
  OpenstaandeFacturen: IFactuur[] = [];
  uitbater: IUitbater;
  constructor(private userService: UserService,
    private msalService: MsalService) { }

  ngOnInit() {
    if (this.msalService.isLoggedIn()) {
      this.msalService.isUitbater();
      this.userService.isuitbater(this.msalService.getUserObjectId()).subscribe(res => {
        this.uitbater = res;
        this.userService.GetFacturenUitbater(this.uitbater.restaurantId).subscribe(res => {
          res.map(factuur => {
            if (factuur.betaald) {
              this.BetaaldeFacturen.push(factuur);
            } else if (!factuur.betaald) {
              this.OpenstaandeFacturen.push(factuur);
            }
          });
        });
      });
    }
  }

  ChangeRequest(bool: boolean) {
    this.BetaaldeFacturenView = bool;
  }
}
