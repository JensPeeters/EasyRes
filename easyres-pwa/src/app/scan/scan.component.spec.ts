import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ZXingScannerModule } from '@zxing/ngx-scanner';

import { ScanComponent } from './scan.component';
import { HttpClientModule } from '@angular/common/http';
import { MsalService } from '../services/msal.service';
import { RouterModule } from '@angular/router';

describe('ScanComponent', () => {
  let component: ScanComponent;
  let fixture: ComponentFixture<ScanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ZXingScannerModule, RouterModule.forRoot([]), HttpClientModule],
      declarations: [ ScanComponent ],
      providers: [MsalService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScanComponent);
    component = fixture.componentInstance;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
