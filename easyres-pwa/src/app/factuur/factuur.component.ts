import { Component, OnInit } from '@angular/core';
import { MsalService } from '../services/msal.service';
import { ActivatedRoute } from '@angular/router';
import { FactuurService } from '../services/factuur.service';
import { IFactuur } from '../services/common.service';

@Component({
  selector: 'app-factuur',
  templateUrl: './factuur.component.html',
  styleUrls: ['./factuur.component.scss']
})
export class FactuurComponent implements OnInit {

  constructor(private msalService: MsalService, private route: ActivatedRoute, private factuurService: FactuurService) { }

  UserId: string;
  TafelNr: number;
  RestaurantId: number;
  factuurLoading: boolean = true;
  factuurFailed: boolean = false;
  factuur: IFactuur;

  ngOnInit() {
    this.TafelNr = Number(this.route.snapshot.paramMap.get('TafelNr'));
    this.RestaurantId = Number(this.route.snapshot.paramMap.get('id'));
    if(this.msalService.isLoggedIn()){
      this.GetUserObjectId();
      this.GenerateFactuur();
    }
  }

  GetUserObjectId(){
    this.UserId = this.msalService.getUserObjectId();
  }

  GenerateFactuur(){
    this.factuurFailed = false;
    this.factuurLoading = true;
    this.factuurService.GenerateFactuur(this.UserId, this.RestaurantId).subscribe(
      res => {
      this.GetFactuur();
    } ,
    err => {
      this.factuurFailed = true;
      this.factuurLoading = false;
    },
    () => {});
  }

  GetFactuur(){
    this.factuurService.GetFactuur(this.UserId,this.RestaurantId).subscribe( res => {
      this.factuur = res;
      this.factuurLoading = false;
    });
  }

}