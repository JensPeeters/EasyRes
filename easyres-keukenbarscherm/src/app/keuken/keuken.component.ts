import { Component, OnInit } from '@angular/core';
import { DataService, IProduct, IBestelling } from '../data.service';


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

  constructor(private serv: DataService) { }

  ngOnInit() {
    this.serv.GetAlleVoedingsbestellingen().subscribe(result => {
      this.Bestellingen = result;
    });

    if (this.UpdateBestelling.Etengereed) {
      this.ProcessList.push();
    } 
    
    if (this.UpdateBestelling.Etengereed == false) {
      this.DoneList.push();
    } 
  }

  Back(bestelling: IBestelling) {
    bestelling.Etengereed = false;
    this.serv.PutVoedingsbestelling(bestelling).subscribe(res => {
      this.serv.GetAlleVoedingsbestellingen().subscribe(result => {
        this.Bestellingen = result;
      });
    });
  }

  Done(bestelling: IBestelling) {
    bestelling.Etengereed = true;
    this.serv.PutVoedingsbestelling(bestelling).subscribe(res => {
      this.serv.GetAlleVoedingsbestellingen().subscribe(result => {
        this.Bestellingen = result;
      });
    });
  }
}
