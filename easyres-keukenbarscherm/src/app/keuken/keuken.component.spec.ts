import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KeukenComponent } from './keuken.component';

describe('KeukenComponent', () => {
  let component: KeukenComponent;
  let fixture: ComponentFixture<KeukenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KeukenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KeukenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
