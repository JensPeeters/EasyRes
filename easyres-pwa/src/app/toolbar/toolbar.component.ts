import { Component, OnInit } from '@angular/core';
import { MsalService } from '../services/msal.service';
import { GoogleAnalyticsService } from '../services/google-analytics.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  constructor(private msalService: MsalService, private analytics: GoogleAnalyticsService) {
  }

  SendEvent(buttonNaam: string) {
    this.analytics.eventEmitter("toolbar", buttonNaam, buttonNaam, 1);
  }

  login() {
    this.msalService.login();
    this.SendEvent("login");
  }

  signup() {
    this.msalService.signup();
    this.SendEvent("singup");
  }

  logout() {
    this.msalService.logout();
    this.SendEvent("logout");
  }

  isUserLoggedIn() {
    return this.msalService.isLoggedIn();
  }

  userfirstname() {
    return this.msalService.getUserFirstName();
  }

  ngOnInit() {
  }
}
