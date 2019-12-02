import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VerstuurBestellingComponent } from './verstuur-bestelling.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MsalService } from '../services/msal.service';

describe('VerstuurBestellingComponent', () => {
  let component: VerstuurBestellingComponent;
  let fixture: ComponentFixture<VerstuurBestellingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterModule.forRoot([]), HttpClientModule],
      declarations: [ VerstuurBestellingComponent ],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VerstuurBestellingComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
