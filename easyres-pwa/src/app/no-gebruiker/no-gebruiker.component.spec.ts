import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoGebruikerComponent } from './no-gebruiker.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MsalService } from '../services/msal.service';

describe('NoGebruikerComponent', () => {
  let component: NoGebruikerComponent;
  let fixture: ComponentFixture<NoGebruikerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoGebruikerComponent ],
      imports: [HttpClientModule, RouterModule.forRoot([])],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoGebruikerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
