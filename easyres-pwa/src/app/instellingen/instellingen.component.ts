import { Component, OnInit } from '@angular/core';
import { MsalService } from '../services/msal.service';
import { UserService } from '../services/user.service';
import { IGebruiker } from '../services/common.service';

@Component({
  selector: 'app-instellingen',
  templateUrl: './instellingen.component.html',
  styleUrls: ['./instellingen.component.scss']
})
export class InstellingenComponent implements OnInit {

  constructor(private msalService: MsalService, private userService: UserService) { }

  factuur: boolean = false;
  gebruiker: IGebruiker;
  userId: string;

  ngOnInit() {
    if(this.msalService.isLoggedIn()){
      this.getUserObjectId();
      this.GetGebruiker();
    }
  }

  getUserObjectId(){
    this.userId = this.msalService.getUserObjectId();
  }

  ChangeBoolean(bool: boolean){
    bool = !bool;
  }

  isUserLoggedIn() {
    return this.msalService.isLoggedIn();
  }s
  GetGebruiker(){
    this.userService.GetGerbuiker(this.userId).subscribe(res =>{
      this.gebruiker = res;
      this.factuur = this.gebruiker.getFactuurByEmail;
    });
  }
  UpdateGebruiker(){
    this.factuur = !this.factuur;
    this.gebruiker.getFactuurByEmail = this.factuur;
    this.userService.updateGebruiker(this.gebruiker,this.userId).subscribe();
  }
}
