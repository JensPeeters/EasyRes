import { Component, OnInit, Input } from '@angular/core';
import { IFactuur } from '../../services/common.service';

@Component({
  selector: 'app-facturenfactuur',
  templateUrl: './facturenfactuur.component.html',
  styleUrls: ['./facturenfactuur.component.scss']
})
export class FacturenfactuurComponent implements OnInit {
  @Input() factuur: IFactuur;

  constructor() { }

  ngOnInit() {
  }

}
