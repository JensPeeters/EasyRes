import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservatieLijstComponent } from './reservatie-lijst.component';

describe('ReservatieLijstComponent', () => {
  let component: ReservatieLijstComponent;
  let fixture: ComponentFixture<ReservatieLijstComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReservatieLijstComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservatieLijstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
