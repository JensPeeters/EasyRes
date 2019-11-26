import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FacturenComponent } from './facturen.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MsalService } from '../services/msal.service';
import { FacturenfactuurComponent } from './facturenfactuur/facturenfactuur.component';

describe('FacturenComponent', () => {
  let component: FacturenComponent;
  let fixture: ComponentFixture<FacturenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FacturenComponent, FacturenfactuurComponent ],
      imports: [HttpClientModule, RouterModule.forRoot([])],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FacturenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
