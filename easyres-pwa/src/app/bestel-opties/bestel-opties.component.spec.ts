import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BestelOptiesComponent } from './bestel-opties.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

describe('BestelOptiesComponent', () => {
  let component: BestelOptiesComponent;
  let fixture: ComponentFixture<BestelOptiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BestelOptiesComponent ],
      imports: [RouterModule.forRoot([])]
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
