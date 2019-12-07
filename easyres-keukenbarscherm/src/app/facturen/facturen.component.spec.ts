import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FacturenComponent } from './facturen.component';

describe('FacturenComponent', () => {
  let component: FacturenComponent;
  let fixture: ComponentFixture<FacturenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FacturenComponent ]
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
