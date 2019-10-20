import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BesteldeProductenComponent } from './bestelde-producten.component';

describe('BesteldeProductenComponent', () => {
  let component: BesteldeProductenComponent;
  let fixture: ComponentFixture<BesteldeProductenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BesteldeProductenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BesteldeProductenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
