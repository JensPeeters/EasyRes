import { Component, OnInit } from '@angular/core';
import { DataService, IProduct, IBestelling } from '../data.service';

@Component({
  selector: 'app-keuken',
  templateUrl: './keuken.component.html',
  styleUrls: ['./keuken.component.scss']
})
export class KeukenComponent implements OnInit {

  Bestellingen: IBestelling[];

  constructor(private serv: DataService) { }
  
  ngOnInit() {
    this.serv.GetAlleVoedingsbestellingen().subscribe(result => {
      this.Bestellingen = result;


    });

  }

  Back() {
    this.serv.GetAlleVoedingsbestellingen().push({EtenGereed: false});
  }

  Done() {
    this.serv.GetAlleVoedingsbestellingen().push({EtenGereed: true});
  }

}
