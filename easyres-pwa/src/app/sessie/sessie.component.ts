import { Component, OnInit } from '@angular/core';
import { SessionService } from '../services/session.service';
import { MsalService } from '../services/msal.service';
import { ISessie } from '../services/common.service';

@Component({
  selector: 'app-sessie',
  templateUrl: './sessie.component.html',
  styleUrls: ['./sessie.component.scss']
})
export class SessieComponent implements OnInit {

  Sessies : ISessie[];
  TafelNr : number = 4;
  UserId: string;

  constructor(private sessieServ : SessionService, private msalService: MsalService) { }

  async ngOnInit() {
    if(this.msalService.isLoggedIn()){
      this.GetUserId();
    }
    this.Sessies = await this.sessieServ.GetSessions(this.UserId).toPromise();
  }
  GetUserId(){
    this.UserId = this.msalService.getUserObjectId();
  }
}
