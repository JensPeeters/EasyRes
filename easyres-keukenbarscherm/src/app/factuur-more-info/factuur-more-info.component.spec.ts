import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FactuurMoreInfoComponent } from './factuur-more-info.component';
import { UserService } from '../services/user.service';
import { MsalService } from '../services/msal.service';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

describe('FactuurMoreInfoComponent', () => {
  let component: FactuurMoreInfoComponent;
  let fixture: ComponentFixture<FactuurMoreInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FactuurMoreInfoComponent ],
      imports: [HttpClientModule, RouterModule.forRoot([])],
      providers: [MsalService, UserService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FactuurMoreInfoComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
