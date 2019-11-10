import { Component, OnInit} from '@angular/core';
import { SessionService } from '../services/session.service';
import { MsalService } from '../services/msal.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-scan',
  templateUrl: './scan.component.html',
  styleUrls: ['./scan.component.scss'],
})
export class ScanComponent implements OnInit {

  UserId: string;
  QRResult: IQRResult;

  constructor(private sessionService: SessionService,
    private msalService: MsalService, private router: Router) { }

  ngOnInit() {
    if(this.msalService.isLoggedIn()){
      this.GetUserId();
    }
  }

  GetUserId(){
    this.UserId = this.msalService.getUserObjectId();
  }

  onCodeResult(resultString: string) {
    this.QRResult = JSON.parse(resultString);
    this.sessionService.CreateSession(this.QRResult.restaurantId,this.QRResult.tafelNr,this.UserId).subscribe(res => {
      this.router.navigateByUrl('/sessie');
    });
  }

}

export interface IQRResult{
  restaurantId: number,
  tafelNr: number
}
