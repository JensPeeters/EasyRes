import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { IBestelling, IRestaurant } from '../services/common.service';
import { UserService, IUitbater } from '../services/user.service';
import { MsalService } from '../services/msal.service';

@Component({
  selector: 'app-bar',
  templateUrl: './bar.component.html',
  styleUrls: ['./bar.component.scss']
})

export class BarComponent implements OnInit {

  Bestellingen: IBestelling[];
  UpdateBestelling: IBestelling;

  ProcessList: IBestelling[];
  DoneList: IBestelling[];
  CancelList: IBestelling[];

  today = new Date();

  uitbater: IUitbater;

  constructor(private serv: DataService, private MsalService : MsalService, private userService: UserService) { }

  ngOnInit() {
    if (this.MsalService.isLoggedIn()){
      this.userService.isuitbater(this.MsalService.getUserObjectId()).subscribe(res =>{
        this.uitbater = res;
        this.serv.GetAlleDrankbestellingen(this.uitbater.restaurantId).subscribe(result => {
          this.Bestellingen = result;
          this.Checklist();
          setInterval(() => {
            this.today = new Date();
         }, 1000);
        });
      });
    }
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
    bestelling.drinkTijdKlaar = this.today;
    this.today = bestelling.drinkTijdKlaar;
    this.serv.Putbestelling(bestelling, this.uitbater.restaurantId).subscribe(res => {
      this.serv.GetAlleDrankbestellingen(this.uitbater.restaurantId).subscribe(result => {
        this.Bestellingen = result;
        this.Checklist();
      });
    });
  }

  Cancel(bestelling: IBestelling) {
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
      if(!element.drinkenStatus && element.dranken != null){
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
