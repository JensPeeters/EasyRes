import { TestBed, async, inject } from '@angular/core/testing';

import { MsalGuard } from './msal.guard';
import { MsalService } from '../services/msal.service';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

describe('MsalGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, RouterModule.forRoot([])],
      providers: [MsalGuard, MsalService]
    });
  });

  it('should be created', inject([MsalGuard], (guard: MsalGuard) => {
    expect(guard).toBeTruthy();
  }));
});
