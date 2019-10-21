import { Component, OnInit } from '@angular/core';
import { DataService, IProduct, IBestelling } from '../data.service';

@Component({
  selector: 'app-bar',
  templateUrl: './bar.component.html',
  styleUrls: ['./bar.component.scss']
})
export class BarComponent implements OnInit {


  Bestellingen: IBestelling[];

  constructor(private serv: DataService) { }

  ngOnInit() {
    this.serv.GetAlleDrankbestellingen().subscribe(result => {
      this.Bestellingen = result;
    });
  }

}
