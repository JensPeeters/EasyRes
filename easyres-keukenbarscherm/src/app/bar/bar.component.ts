import { Component, OnInit } from '@angular/core';
import { DataService, IProduct } from '../data.service';

@Component({
  selector: 'app-bar',
  templateUrl: './bar.component.html',
  styleUrls: ['./bar.component.scss']
})
export class BarComponent implements OnInit {

  Result : IProduct;

  constructor(/*private serv : DataService*/) { }

  ngOnInit() {
    /*this.serv.GetAlleDrankbestellingen().subscribe(result => {
      this.Result = result;
    });*/
  }

}
