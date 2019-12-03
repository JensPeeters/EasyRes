import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantComponent } from './restaurant.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { MsalService } from '../services/msal.service';
import { Ng2CompleterModule } from 'ng2-completer';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { FilterService } from '../services/filter.service';

describe('RestaurantComponent', () => {
  let component: RestaurantComponent;
  let fixture: ComponentFixture<RestaurantComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule, RouterModule.forRoot([]), HttpClientModule, Ng2CompleterModule],
      declarations: [ RestaurantComponent ],
      providers: [MsalService, GoogleAnalyticsService, FilterService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurantComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Should give gemeentes of België when België is selected', () => {
    component.Filters[0].value = "België";
    var result = component.ChangeLocation({naam: "Gemeente", value: "", active: false});
    expect(result).toBe(component.GemeentesBelgie);
  });

  it('Should give gemeentes of Nederland when Nederland is selected', () => {
    component.Filters[0].value = "Nederland";
    var result = component.ChangeLocation({naam: "Gemeente", value: "", active: false});
    expect(result).toBe(component.GemeentesNederland);
  });

  it('ChangeFilter() should change boolean value', () => {
    component.ChangeFilter(component.Filters[0]);
    expect(component.Filters[0].active).toBe(true);
  });

});
