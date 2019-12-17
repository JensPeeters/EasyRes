import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FavorietenComponent } from './favorieten.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MsalService } from '../services/msal.service';
import { RestaurantService } from '../services/restaurant.service';
import { Observable } from 'rxjs';
import { IRestaurant } from '../services/common.service';

describe('FavorietenComponent', () => {
  let component: FavorietenComponent;
  let fixture: ComponentFixture<FavorietenComponent>;
  let testResService: RestaurantService = new RestaurantService(null,null);

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, HttpClientModule, RouterModule.forRoot([]) ],
      declarations: [ FavorietenComponent ],
      providers: [MsalService,
        { provide: RestaurantService, useValue: testResService }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavorietenComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Expect IsEmpty() to return true when Restaurants is empty', () => {
    var Restaurants = [];
    var result = component.IsEmpty(Restaurants);
    expect(result).toBe(true);
  });

  it('Zoeknaam should be equel to the text in the searchinput and zoekterm should be updated to (naam={zoeknaam}) when clicked on searchicon', () => {
    let restaurants = new Promise<IRestaurant[]>((resolve, reject) => {});
    spyOn(testResService, 'GetRestaurants').and.returnValue(restaurants)
    fixture.detectChanges();
    const htmlElement : HTMLElement = fixture.nativeElement;
    let input = htmlElement.querySelector('input');
    let span = htmlElement.querySelector('span');
    input.value = 'restaurantnaam';
    input.dispatchEvent(new Event('input'));
    span.click();
    fixture.detectChanges();
    expect(component.zoeknaam).toBe("restaurantnaam");
    expect(component.zoekterm).toBe("naam=restaurantnaam");
  });

});
