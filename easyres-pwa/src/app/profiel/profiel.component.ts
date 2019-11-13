import { Component, OnInit } from '@angular/core';
import { MsalService } from '../services/msal.service';
import { GoogleAnalyticsService } from '../services/google-analytics.service';

@Component({
  selector: 'app-profiel',
  templateUrl: './profiel.component.html',
  styleUrls: ['./profiel.component.scss']
})
export class ProfielComponent implements OnInit {

  constructor(private msalService: MsalService, private analytics: GoogleAnalyticsService) { }

  SendEvent(buttonNaam: string) {
    this.analytics.eventEmitter("profiel", buttonNaam, buttonNaam, 1);
  }

  isUserLoggedIn() {
    return this.msalService.isLoggedIn();
  }

  userfirstname() {
    return this.msalService.getUserFirstName();
  }

  userfamilyname() {
    return this.msalService.getUserFamilyName();
  }

  useremail() {
    return this.msalService.getUserEmail();
  }

  editprofile() {
    this.SendEvent("Profiel aanpassen");
    return this.msalService.editProfile();
  }

  ngOnInit() {
  }

}
