import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BestelComponent } from './bestel.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { MsalService } from '../services/msal.service';
import { FormsModule } from '@angular/forms';

describe('BestelComponent', () => {
  let component: BestelComponent;
  let fixture: ComponentFixture<BestelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterModule.forRoot([]), HttpClientModule, FormsModule],
      declarations: [ BestelComponent ],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BestelComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should collapse the open menu when openingen any of the other menus ', () => {
    component.buttons = [
      {
        type: 'Dranken',
        nr: 1,
        state: false
      },
      {
        type: 'Voorgerechten',
        nr: 2,
        state: true
      }
    ];
    component.ChangeToFalse(component.buttons[0].state,component.buttons[0].nr)
    expect(component.buttons[1].state).toBe(false);
  });

});
