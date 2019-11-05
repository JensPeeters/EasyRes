import { Component, OnInit } from '@angular/core';
import { MsalService } from '../services/msal.service';

@Component({
  selector: 'app-bestellingen',
  templateUrl: './bestellingen.component.html',
  styleUrls: ['./bestellingen.component.scss']
})
export class BestellingenComponent implements OnInit {
  UserId : string;
  constructor(private msalService: MsalService) { }

  ngOnInit() {
    if(this.msalService.isLoggedIn())
      this.GetUserObjectId();
  }
  GetUserObjectId(){
    this.UserId = this.msalService.getUserObjectId();
    console.log(this.UserId);
  }

}
