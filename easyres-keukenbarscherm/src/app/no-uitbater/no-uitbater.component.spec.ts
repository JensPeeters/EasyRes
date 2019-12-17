import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoUitbaterComponent } from './no-uitbater.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MsalService } from '../services/msal.service';

describe('NoUitbaterComponent', () => {
  let component: NoUitbaterComponent;
  let fixture: ComponentFixture<NoUitbaterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoUitbaterComponent ],
      imports: [HttpClientModule, RouterModule.forRoot([])],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoUitbaterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
