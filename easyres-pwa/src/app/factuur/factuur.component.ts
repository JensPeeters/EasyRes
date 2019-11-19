import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MsalService } from '../services/msal.service';
import { ActivatedRoute } from '@angular/router';
import { FactuurService } from '../services/factuur.service';
import { IFactuur } from '../services/common.service';
import { staticViewQueryIds } from '@angular/compiler';
import { FacturenComponent } from '../facturen/facturen.component';
import { Action } from 'rxjs/internal/scheduler/Action';
import { async } from 'q';
import { ActionSequence } from 'protractor';

declare var paypal;

@Component({
  selector: 'app-factuur',
  templateUrl: './factuur.component.html',
  styleUrls: ['./factuur.component.scss']
})
export class FactuurComponent implements OnInit {

  @ViewChild('paypal', { static: true }) FacturenComponent: ElementRef;

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
    if (this.msalService.isLoggedIn()) {
      this.GetUserObjectId();
      this.GenerateFactuur();
    }

    paypal
      .Buttons({
        createOrder: (data, actions) => {
          return actions.order.create({
            purchase_units: [
              {
                description: this.factuur.id,
                amount: {
                  currency_code: 'USD',
                  Value: this.factuur.totaalPrijs
                }
              }
            ]

          });
        },
        onApprove: async (data, actions) => {
          const order = await actions.order.capture();
          this.factuur.betaald = true;
        },
        onError: err => {
          console.log(err);
          console.log(this.factuur.totaalPrijs);
        }

      })
      .render(this.FacturenComponent.nativeElement);
  }

  GetUserObjectId() {
    this.UserId = this.msalService.getUserObjectId();
  }

  GenerateFactuur() {
    this.factuurFailed = false;
    this.factuurLoading = true;
    this.factuurService.GenerateFactuur(this.UserId, this.RestaurantId).subscribe(
      res => {
        this.GetFactuur();
      },
      err => {
        this.factuurFailed = true;
        this.factuurLoading = false;
      },
      () => { });
  }

  GetFactuur() {
    this.factuurService.GetFactuur(this.UserId, this.RestaurantId).subscribe(res => {
      this.factuur = res;
      this.factuurLoading = false;
    });
  }

}