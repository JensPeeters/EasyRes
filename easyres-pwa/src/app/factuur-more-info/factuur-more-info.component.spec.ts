import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FactuurMoreInfoComponent } from './factuur-more-info.component';
import { HttpClientModule } from '@angular/common/http';
import { MsalService } from '../services/msal.service';
import { FactuurService } from '../services/factuur.service';
import { RouterModule } from '@angular/router';

describe('FactuurMoreInfoComponent', () => {
  let component: FactuurMoreInfoComponent;
  let fixture: ComponentFixture<FactuurMoreInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FactuurMoreInfoComponent ],
      imports: [HttpClientModule, RouterModule.forRoot([])],
      providers: [MsalService, FactuurService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FactuurMoreInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
