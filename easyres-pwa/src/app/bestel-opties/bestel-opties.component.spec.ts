import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BestelOptiesComponent } from './bestel-opties.component';

describe('BestelOptiesComponent', () => {
  let component: BestelOptiesComponent;
  let fixture: ComponentFixture<BestelOptiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BestelOptiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BestelOptiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
