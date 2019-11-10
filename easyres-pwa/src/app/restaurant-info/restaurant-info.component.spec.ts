import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantInfoComponent } from './restaurant-info.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from '../app-routing.module';
import { RestaurantComponent } from '../restaurant/restaurant.component';
import { ReservatieComponent } from '../reservatie/reservatie.component';
import { ReservatieLijstComponent } from '../reservatie-lijst/reservatie-lijst.component';
import { BesteldeProductenComponent } from '../bestelde-producten/bestelde-producten.component';
import { VerstuurBestellingComponent } from '../verstuur-bestelling/verstuur-bestelling.component';
import { BestelComponent } from '../bestel/bestel.component';
import { SessieComponent } from '../sessie/sessie.component';
import { FavorietenComponent } from '../favorieten/favorieten.component';
import { BestellingenComponent } from '../bestellingen/bestellingen.component';
import { BestelOptiesComponent } from '../bestel-opties/bestel-opties.component';
import { Ng2CompleterModule } from 'ng2-completer';

describe('RestaurantInfoComponent', () => {
  let component: RestaurantInfoComponent;
  let fixture: ComponentFixture<RestaurantInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, HttpClientModule, AppRoutingModule, Ng2CompleterModule ],
      declarations: [ RestaurantInfoComponent, RestaurantComponent, 
        ReservatieComponent, BesteldeProductenComponent, 
        VerstuurBestellingComponent, BestelComponent, 
        SessieComponent, FavorietenComponent, 
        ReservatieLijstComponent, BestellingenComponent, 
        BestelOptiesComponent  ]

    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurantInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
