import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservatieLijstComponent } from './reservatie-lijst.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { MsalService } from '../services/msal.service';
import { GoogleAnalyticsService } from '../services/google-analytics.service';
import { By } from '@angular/platform-browser';

describe('ReservatieLijstComponent', () => {
  let component: ReservatieLijstComponent;
  let fixture: ComponentFixture<ReservatieLijstComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, RouterModule.forRoot([])],
      declarations: [ ReservatieLijstComponent ],
      providers: [MsalService, GoogleAnalyticsService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservatieLijstComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Expect isEmpty() to return true when Restaurants is empty', () => {
    var reservaties = [];
    var result = component.isEmpty(reservaties);
    expect(result).toBe(true);
  });

  it('Expect showMore() to add 10 to the pagesize', () => {
    //fixture.detectChanges();
    component.showMore();
    expect(component.aantal).toBe(20);
  });

});
