import { Component, OnInit } from '@angular/core';
import { DataService, IBestelling } from '../data.service';

@Component({
  selector: 'app-keuken',
  templateUrl: './keuken.component.html',
  styleUrls: ['./keuken.component.scss']
})

export class KeukenComponent implements OnInit {

  Bestellingen: IBestelling[];
  UpdateBestelling: IBestelling;

  ProcessList: IBestelling[];
  DoneList: IBestelling[];

  today = new Date();

  constructor(private serv: DataService) { }

  ngOnInit() {
    this.serv.GetAlleVoedingsbestellingen().subscribe(result => {
      this.Bestellingen = result;
      this.Checklist();
      setInterval(() => {
        this.today = new Date();
     }, 1000);
    });
  }

  Back(bestelling: IBestelling) {
    bestelling.etenGereed = false;
    this.serv.Putbestelling(bestelling).subscribe(res => {
      this.serv.GetAlleVoedingsbestellingen().subscribe(result => {
        this.Bestellingen = result;
        this.Checklist();
      });
    });
  }

  Done(bestelling: IBestelling) {
    bestelling.etenGereed = true;
    bestelling.finaleTijd = this.today;
    this.today = bestelling.finaleTijd;
    this.serv.Putbestelling(bestelling).subscribe(res => {
      this.serv.GetAlleVoedingsbestellingen().subscribe(result => {
        this.Bestellingen = result;
        this.Checklist();
      });
    });
  }

  Checklist() {
    this.DoneList = [];
    this.ProcessList = [];

    this.Bestellingen.forEach(element => {
      if (element.etenGereed) {
        this.DoneList.push(element);
      } 
      else if (element.etenswaren.length != 0) {
        this.ProcessList.push(element);
      }
    });
  }
}
