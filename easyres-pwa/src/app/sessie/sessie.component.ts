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

  Sessies: ISessie[] = [];
  UserId: string;

  constructor(private sessieServ: SessionService, private msalService: MsalService) { }

  ngOnInit() {
    if (this.msalService.isLoggedIn()) {
      this.GetUserId();
    }
    this.sessieServ.GetSessions(this.UserId).subscribe(res => {
      this.Sessies = res;
    });
  }

  GetUserId() {
    this.UserId = this.msalService.getUserObjectId();
  }
}
