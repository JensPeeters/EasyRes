import { Component, OnInit, OnDestroy } from '@angular/core';
import { DataService } from '../services/data.service';
import { IBestelling, IRestaurant } from '../services/common.service';
import { UserService, IUitbater } from '../services/user.service';
import { MsalService } from '../services/msal.service';

@Component({
  selector: 'app-bar',
  templateUrl: './bar.component.html',
  styleUrls: ['./bar.component.scss']
})

export class BarComponent implements OnInit, OnDestroy {

  Bestellingen: IBestelling[];
  UpdateBestelling: IBestelling;

  ProcessList: IBestelling[];
  DoneList: IBestelling[];
  CancelList: IBestelling[];

  uitbater: IUitbater;

  reloadInterval;

  modalOpen: boolean = false;
  
  constructor(private serv: DataService, private MsalService : MsalService, private userService: UserService) { }

  ngOnInit() {
    if (this.MsalService.isLoggedIn()){
      this.userService.isuitbater(this.MsalService.getUserObjectId()).subscribe(res =>{
        this.uitbater = res;
        this.GetAlleDrankBestellingen();
        this.reloadInterval = setInterval(() => {
          this.GetAlleDrankBestellingen();
        }, 1000);
      });
    }
  }

  ngOnDestroy(){
    clearInterval(this.reloadInterval);
  }

  GetAlleDrankBestellingen(){
    if(!this.modalOpen){
      this.serv.GetAlleDrankbestellingen(this.uitbater.restaurantId).subscribe(res => {
        this.Bestellingen = res;
        this.Checklist();
      })
    }
  }

  ChangeModalOpen(){
    this.modalOpen = !this.modalOpen;
  }

  Back(bestelling: IBestelling) {
    bestelling.drinkenGereed = false;
    this.serv.Putbestelling(bestelling, this.uitbater.restaurantId).subscribe(res => {
      this.serv.GetAlleDrankbestellingen(this.uitbater.restaurantId).subscribe(result => {
        this.Bestellingen = result;
        this.Checklist();
      });
    });
  }

  Done(bestelling: IBestelling) {
    bestelling.drinkenGereed = true;
    bestelling.drinkTijdKlaar = new Date();
    this.serv.Putbestelling(bestelling, this.uitbater.restaurantId).subscribe(res => {
      this.serv.GetAlleDrankbestellingen(this.uitbater.restaurantId).subscribe(result => {
        this.Bestellingen = result;
        this.Checklist();
      });
    });
  }

  Cancel(bestelling: IBestelling) {
    this.ChangeModalOpen();
    bestelling.drinkenStatus = true;
    this.serv.Putbestelling(bestelling, this.uitbater.restaurantId).subscribe(res => {
      this.serv.GetAlleDrankbestellingen(this.uitbater.restaurantId).subscribe(result => {
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
      if(!element.drinkenStatus && element.dranken != null && element.dranken.length != 0){
        if (element.drinkenGereed) {
          this.DoneList.push(element);
        }
        else{
          this.ProcessList.push(element);
        }
      }
      else{
        this.CancelList.push(element);
      }
    });
  }
}
