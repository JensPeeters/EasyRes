import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoRestaurantComponent } from './no-restaurant.component';

describe('NoRestaurantComponent', () => {
  let component: NoRestaurantComponent;
  let fixture: ComponentFixture<NoRestaurantComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoRestaurantComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoRestaurantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
