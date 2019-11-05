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
    bestelling.etenGereed = false;
    this.serv.Putbestelling(bestelling).subscribe(res => {
      this.serv.GetAlleDrankbestellingen().subscribe(result => {
        this.Bestellingen = result;
        this.Checklist();
      });
    });
  }

  Done(bestelling: IBestelling) {
    bestelling.etenGereed = true;
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
      if (element.etenGereed) {
        this.DoneList.push(element);
      } else {
        this.ProcessList.push(element);
      }
    });
  }

}
