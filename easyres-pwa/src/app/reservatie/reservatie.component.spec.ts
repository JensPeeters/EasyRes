import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservatieComponent } from './reservatie.component';

describe('ReservatieComponent', () => {
  let component: ReservatieComponent;
  let fixture: ComponentFixture<ReservatieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReservatieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservatieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
