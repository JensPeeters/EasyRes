import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservatieComponent } from './reservatie.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MsalService } from '../services/msal.service';

describe('ReservatieComponent', () => {
  let component: ReservatieComponent;
  let fixture: ComponentFixture<ReservatieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule, HttpClientModule, RouterModule.forRoot([])],
      declarations: [ ReservatieComponent ],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservatieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
