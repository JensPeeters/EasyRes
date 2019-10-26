import { Component, OnInit } from '@angular/core';
import { IReservatie, RestaurantService } from '../services/restaurant.service';

@Component({
  selector: 'app-reservatie-lijst',
  templateUrl: './reservatie-lijst.component.html',
  styleUrls: ['./reservatie-lijst.component.scss']
})
export class ReservatieLijstComponent implements OnInit {

  reservaties: IReservatie[];
  userid: string;
  aantal: number = 10;

  constructor(private ResService : RestaurantService) {
    //Nog aanpassen nadat userid beschikbaar is
    this.userid = "test"
   }

  async ngOnInit() {
    this.ResService.GetReservationsByUserID(this.userid).subscribe(result => {
      this.reservaties = result;
    })
    this.reservaties = this.reservaties
  }

  Annuleer(reservatieId){
    this.ResService.DeleteReservationByID(reservatieId).subscribe(a => {
      this.ResService.GetReservationsByUserID(this.userid).subscribe(result => {
        this.reservaties = result;
      })
    });
  }

  isEmpty(arr){
    if (!(arr.length > 0)){return true;}
    else{return false;}
  }

  showMore(){
    this.aantal += 10;
  }

}
