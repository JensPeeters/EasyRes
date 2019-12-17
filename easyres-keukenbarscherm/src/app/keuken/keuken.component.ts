import { Component, OnInit, OnDestroy } from '@angular/core';
import { DataService } from '../services/data.service';
import { IBestelling } from '../services/common.service';
import { UserService, IUitbater } from '../services/user.service';
import { MsalService } from '../services/msal.service';

@Component({
  selector: 'app-keuken',
  templateUrl: './keuken.component.html',
  styleUrls: ['./keuken.component.scss']
})

export class KeukenComponent implements OnInit, OnDestroy {

  Bestellingen: IBestelling[];
  UpdateBestelling: IBestelling;

  ProcessList: IBestelling[];
  DoneList: IBestelling[];
  CancelList: IBestelling[];

  uitbater: IUitbater;

  reloadInterval;
  modalOpen: boolean = false;

  constructor(private serv: DataService, private msalService: MsalService, private userService: UserService) { }

  ngOnInit() {
    if (this.msalService.isLoggedIn()) {
      this.msalService.isUitbater();
      this.userService.isuitbater(this.msalService.getUserObjectId()).subscribe(res => {
        this.uitbater = res;
        this.GetAlleVoedingsbestellingen();
        this.reloadInterval = setInterval(() => {
          this.GetAlleVoedingsbestellingen();
        }, 1000);
      });
    }
  }

  ngOnDestroy(){
    clearInterval(this.reloadInterval);
  }

  GetAlleVoedingsbestellingen() {
    if (!this.modalOpen) {
      this.serv.GetAlleVoedingsbestellingen(this.uitbater.restaurantId).subscribe(res => {
        this.Bestellingen = res;
        this.Checklist();
      });
    }
  }

  ChangeModalOpen() {
    this.modalOpen = !this.modalOpen;
  }

  Back(bestelling: IBestelling) {
    bestelling.etenGereed = false;
    this.serv.Putbestelling(bestelling, this.uitbater.restaurantId).subscribe(res => {
      this.serv.GetAlleVoedingsbestellingen(this.uitbater.restaurantId).subscribe(result => {
        this.Bestellingen = result;
        this.Checklist();
      });
    });
  }

  Done(bestelling: IBestelling) {
    bestelling.etenGereed = true;
    bestelling.eetTijdKlaar = new Date();
    this.serv.Putbestelling(bestelling, this.uitbater.restaurantId).subscribe(res => {
      this.serv.GetAlleVoedingsbestellingen(this.uitbater.restaurantId).subscribe(result => {
        this.Bestellingen = result;
        this.Checklist();
      });
    });
  }

  Cancel(bestelling: IBestelling) {
    this.ChangeModalOpen();
    bestelling.etenStatus = true;
    this.serv.Putbestelling(bestelling, this.uitbater.restaurantId).subscribe(res => {
      this.serv.GetAlleVoedingsbestellingen(this.uitbater.restaurantId).subscribe(result => {
        this.Bestellingen = result;
        this.Checklist();
      });
    });
  }

  Checklist() {
    this.DoneList = [];
    this.ProcessList = [];
    this.CancelList = [];
    this.Bestellingen.forEach(element => {
      if (!element.etenStatus && element.etenswaren != null && element.etenswaren.length != 0) {
        if (element.etenGereed) {
          this.DoneList.push(element);
        } else {
          this.ProcessList.push(element);
        }
      } else {
        this.CancelList.push(element);
      }
    });
  }
}
