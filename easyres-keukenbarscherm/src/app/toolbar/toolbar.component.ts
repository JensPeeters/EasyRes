import { Component, OnInit } from '@angular/core';
import { MsalService } from '../services/msal.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  today = new Date();

  constructor(private msalService: MsalService) { }

  login() {
    this.msalService.login();
  }

  signup() {
    this.msalService.signup();
  }

  logout() {
    this.msalService.logout();
  }

  isUserLoggedIn() {
    return this.msalService.isLoggedIn();
  }

  userfirstname() {
    return this.msalService.getUserFirstName();
  }

  ngOnInit() {
    if (this.isUserLoggedIn()) {
      this.msalService.isUitbater();
    }
    setInterval(() => {
      this.today = new Date();
   }, 1000);
  }

}
