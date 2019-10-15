import { Component, OnInit } from '@angular/core';
import { DataService, IProduct } from '../data.service';

@Component({
  selector: 'app-keuken',
  templateUrl: './keuken.component.html',
  styleUrls: ['./keuken.component.scss']
})
export class KeukenComponent implements OnInit {

  Result : IProduct;

  constructor(/*private serv : DataService*/) { }

  ngOnInit() {
    /*
    this.serv.GetAlleVoedingsbestellingen().subscribe(result => {
      this.Result = result;
    });
    */
  }

}
