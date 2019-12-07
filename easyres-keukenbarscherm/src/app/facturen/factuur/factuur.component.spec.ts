import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FactuurComponent } from './factuur.component';
import { RouterModule } from '@angular/router';

describe('FactuurComponent', () => {
  let component: FactuurComponent;
  let fixture: ComponentFixture<FactuurComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterModule.forRoot([])],
      declarations: [ FactuurComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FactuurComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
