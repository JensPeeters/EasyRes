import { Component, OnInit } from '@angular/core';
import { MsalService } from '../services/msal.service';

@Component({
  selector: 'app-no-uitbater',
  templateUrl: './no-uitbater.component.html',
  styleUrls: ['./no-uitbater.component.scss']
})
export class NoUitbaterComponent implements OnInit {

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
