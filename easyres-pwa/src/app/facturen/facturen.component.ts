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

  SorteerOp = 'Datum';
  sorteerKeuzes: string[] = ['Datum', 'Restaurant', 'Factuurnummer', 'Prijs'];

  constructor(private factuurService: FactuurService, private msalService: MsalService) { }

  ngOnInit() {
    if (this.msalService.isLoggedIn()) {
      this.GetUserObjectId();
    }
    this.getFacturen();
  }

  getFacturen() {
    this.factuurService.GetFacturen(this.UserId, this.SorteerOp).subscribe( res => {
      this.Facturen = res;
    });
  }

  Sorteren(item) {
    this.SorteerOp = item;
    this.getFacturen();
  }

  GetUserObjectId() {
    this.UserId = this.msalService.getUserObjectId();
  }

}
