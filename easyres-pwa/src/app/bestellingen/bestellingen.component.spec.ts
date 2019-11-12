import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BestellingenComponent } from './bestellingen.component';
import { MsalService } from '../services/msal.service';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

describe('BestellingenComponent', () => {
  let component: BestellingenComponent;
  let fixture: ComponentFixture<BestellingenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BestellingenComponent ],
      imports: [HttpClientModule, RouterModule.forRoot([])],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BestellingenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
