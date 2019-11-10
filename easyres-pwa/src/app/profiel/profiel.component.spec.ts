import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfielComponent } from './profiel.component';
import { MsalService } from '../services/msal.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

describe('ProfielComponent', () => {
  let component: ProfielComponent;
  let fixture: ComponentFixture<ProfielComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule, HttpClientModule, RouterModule.forRoot([])],
      declarations: [ ProfielComponent ],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfielComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
