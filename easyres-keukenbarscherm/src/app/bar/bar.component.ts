import { Component, OnInit } from '@angular/core';
import { DataService, IBestelling } from '../services/data.service';

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

  constructor(private serv: DataService) { }

  ngOnInit() {
    this.serv.GetAlleDrankbestellingen().subscribe(result => {
      this.Bestellingen = result;
      this.Checklist();
      setInterval(() => {
        this.today = new Date();
     }, 1000);
    });
  }

  Back(bestelling: IBestelling) {
    bestelling.drinkenGereed = false;
    this.serv.Putbestelling(bestelling).subscribe(res => {
      this.serv.GetAlleDrankbestellingen().subscribe(result => {
        this.Bestellingen = result;
        this.Checklist();
      });
    });
  }

  Done(bestelling: IBestelling) {
    bestelling.drinkenGereed = true;
    bestelling.drinkTijdKlaar = this.today;
    this.today = bestelling.drinkTijdKlaar;
    this.serv.Putbestelling(bestelling).subscribe(res => {
      this.serv.GetAlleDrankbestellingen().subscribe(result => {
        this.Bestellingen = result;
        this.Checklist();
      });
    });
  }

  Cancel(bestelling: IBestelling) {
    bestelling.drinkenStatus = false;
    this.serv.Putbestelling(bestelling).subscribe(res => {
      this.serv.GetAlleDrankbestellingen().subscribe(result => {
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
      if (element.drinkenGereed && element.dranken != null) {
        this.DoneList.push(element);
      }
      else if (element.drinkenStatus == false){
        this.CancelList.push(element);
      }
      else if (element.dranken.length != 0 && element.drinkenGereed == false) {
        this.ProcessList.push(element);
      }
    });
  }
}
