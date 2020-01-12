import { Component, OnInit } from '@angular/core';
import { IFactuur, UserService } from '../services/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-factuur-more-info',
  templateUrl: './factuur-more-info.component.html',
  styleUrls: ['./factuur-more-info.component.scss']
})
export class FactuurMoreInfoComponent implements OnInit {

  constructor(private route: ActivatedRoute, private userService: UserService) { }

  factuurId: number;
  factuur: IFactuur;

  ngOnInit() {
    this.factuurId = Number(this.route.snapshot.paramMap.get('id'));
    this.GetFactuur();
  }

  GetFactuur(){
    this.userService.GetFactuurByid(this.factuurId).subscribe( res => {
      this.factuur = res;
    });
  }

}
