import { TestBed, async, inject } from '@angular/core/testing';

import { MsalGuard } from './msal.guard';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

describe('MsalGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientModule, RouterModule.forRoot([]) ],
      providers: [ MsalGuard ]
    });
  });

  it('should ...', inject([MsalGuard], (guard: MsalGuard) => {
    expect(guard).toBeTruthy();
  }));
});
