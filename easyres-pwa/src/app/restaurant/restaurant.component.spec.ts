import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantComponent } from './restaurant.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { MsalService } from '../services/msal.service';

describe('RestaurantComponent', () => {
  let component: RestaurantComponent;
  let fixture: ComponentFixture<RestaurantComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule, RouterModule.forRoot([]), HttpClientModule],
      declarations: [ RestaurantComponent ],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
