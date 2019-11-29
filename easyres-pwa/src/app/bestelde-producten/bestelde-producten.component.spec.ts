import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BesteldeProductenComponent } from './bestelde-producten.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MsalService } from '../services/msal.service';
import { GoogleAnalyticsService } from '../services/google-analytics.service';

describe('BesteldeProductenComponent', () => {
  let component: BesteldeProductenComponent;
  let fixture: ComponentFixture<BesteldeProductenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterModule.forRoot([]), HttpClientModule],
      declarations: [ BesteldeProductenComponent ],
      providers: [MsalService, GoogleAnalyticsService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BesteldeProductenComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
