import { Component, OnInit } from '@angular/core';
import { DataService, IProduct, IBestelling } from '../data.service';

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

  today: number = Date.now();


  constructor(private serv: DataService) { }

  ngOnInit() {
    this.serv.GetAlleDrankbestellingen().subscribe(result => {
      this.Bestellingen = result;
      this.Checklist();
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

    this.Bestellingen.forEach(element => {
      if (element.drinkenGereed && element.dranken != null) {
        this.DoneList.push(element);
      }
      else if (element.dranken.length != 0) {
        this.ProcessList.push(element);
      }
    });
  }
}
