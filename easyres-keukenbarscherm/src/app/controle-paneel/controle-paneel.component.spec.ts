import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ControlePaneelComponent } from './controle-paneel.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

describe('ControlePaneelComponent', () => {
  let component: ControlePaneelComponent;
  let fixture: ComponentFixture<ControlePaneelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports:[ FormsModule,HttpClientModule],
      declarations: [ ControlePaneelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ControlePaneelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
