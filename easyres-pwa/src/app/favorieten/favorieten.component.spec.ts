import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FavorietenComponent } from './favorieten.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MsalService } from '../services/msal.service';

describe('FavorietenComponent', () => {
  let component: FavorietenComponent;
  let fixture: ComponentFixture<FavorietenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, HttpClientModule, RouterModule.forRoot([]) ],
      declarations: [ FavorietenComponent ],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavorietenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
