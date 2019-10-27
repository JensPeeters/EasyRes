import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservatieLijstComponent } from './reservatie-lijst.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { MsalService } from '../services/msal.service';

describe('ReservatieLijstComponent', () => {
  let component: ReservatieLijstComponent;
  let fixture: ComponentFixture<ReservatieLijstComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, RouterModule.forRoot([])],
      declarations: [ ReservatieLijstComponent ],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservatieLijstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
