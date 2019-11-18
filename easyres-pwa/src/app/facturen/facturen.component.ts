import { Component, OnInit } from '@angular/core';
import { FactuurService } from '../services/factuur.service';
import { MsalService } from '../services/msal.service';
import { IFactuur } from '../services/common.service';

@Component({
  selector: 'app-facturen',
  templateUrl: './facturen.component.html',
  styleUrls: ['./facturen.component.scss']
})
export class FacturenComponent implements OnInit {

  Facturen: IFactuur[] = [];
  UserId: string;
  constructor(private factuurService: FactuurService, private msalService: MsalService) { }

  ngOnInit() {
    if (this.msalService.isLoggedIn()) {
      this.GetUserObjectId();
    }
    this.factuurService.GetFacturen(this.UserId).subscribe( res => {
      this.Facturen = res;
    });
  }

  GetUserObjectId() {
    this.UserId = this.msalService.getUserObjectId();
  }

}
