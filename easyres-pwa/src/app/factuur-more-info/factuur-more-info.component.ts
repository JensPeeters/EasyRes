import { Component, OnInit } from '@angular/core';
import { IFactuur } from '../services/common.service';
import { MsalService } from '../services/msal.service';
import { FactuurService } from '../services/factuur.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-factuur-more-info',
  templateUrl: './factuur-more-info.component.html',
  styleUrls: ['./factuur-more-info.component.scss']
})
export class FactuurMoreInfoComponent implements OnInit {

  constructor(private msalService: MsalService, private route: ActivatedRoute, private factuurService: FactuurService) { }

  UserId: string;
  FactuurId: number;
  factuur: IFactuur;

  ngOnInit() {
    this.FactuurId = Number(this.route.snapshot.paramMap.get('id'));
    if (this.msalService.isLoggedIn()) {
      this.GetUserObjectId();
    }
    this.GetFactuur();
  }

  GetUserObjectId() {
    this.UserId = this.msalService.getUserObjectId();
  }

  GetFactuur() {
    this.factuurService.GetFactuurById(this.FactuurId).subscribe( res => {
      this.factuur = res;
    });
  }

}
