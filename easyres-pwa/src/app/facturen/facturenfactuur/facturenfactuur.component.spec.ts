import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FacturenfactuurComponent } from './facturenfactuur.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MsalService } from '../../services/msal.service';

describe('FacturenfactuurComponent', () => {
  let component: FacturenfactuurComponent;
  let fixture: ComponentFixture<FacturenfactuurComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FacturenfactuurComponent ],
      imports: [HttpClientModule, RouterModule.forRoot([])],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FacturenfactuurComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
