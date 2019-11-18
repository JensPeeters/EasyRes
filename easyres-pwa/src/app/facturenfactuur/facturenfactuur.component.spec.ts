import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FacturenfactuurComponent } from './facturenfactuur.component';

describe('FacturenfactuurComponent', () => {
  let component: FacturenfactuurComponent;
  let fixture: ComponentFixture<FacturenfactuurComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FacturenfactuurComponent ]
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
