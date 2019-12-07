import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FacturenComponent } from './facturen.component';
import { FactuurComponent } from './factuur/factuur.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

describe('FacturenComponent', () => {
  let component: FacturenComponent;
  let fixture: ComponentFixture<FacturenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, RouterModule.forRoot([])],
      declarations: [ FacturenComponent, FactuurComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FacturenComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
