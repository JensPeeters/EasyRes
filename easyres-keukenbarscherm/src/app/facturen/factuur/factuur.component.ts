import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { IFactuur } from 'src/app/services/user.service';

@Component({
  selector: 'app-factuur',
  templateUrl: './factuur.component.html',
  styleUrls: ['./factuur.component.scss']
})
export class FactuurComponent implements OnInit {
  @Input() factuur: IFactuur;
  constructor() {
    
  }

  ngOnInit() {
    
  }

}
