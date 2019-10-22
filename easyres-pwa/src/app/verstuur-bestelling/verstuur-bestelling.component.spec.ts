import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VerstuurBestellingComponent } from './verstuur-bestelling.component';

describe('VerstuurBestellingComponent', () => {
  let component: VerstuurBestellingComponent;
  let fixture: ComponentFixture<VerstuurBestellingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VerstuurBestellingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VerstuurBestellingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
