import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MsalService } from '../services/msal.service';

@Component({
  selector: 'app-no-gebruiker',
  templateUrl: './no-gebruiker.component.html',
  styleUrls: ['./no-gebruiker.component.scss']
})
export class NoGebruikerComponent implements OnInit {

  seconden: number = 10;
  interval;

  constructor(private msalService: MsalService) { }

  ngOnInit() {
    this.interval = setInterval(() => {
      this.checkLogout();
    }, 1000);
  }

  checkLogout() {
    if (this.seconden <= 1) {
      this.loguit();
      this.seconden = 10;
      clearInterval(this.interval);
    } else {
      this.seconden--;
    }
  }

  loguit() {
    this.msalService.logout();
  }

}
