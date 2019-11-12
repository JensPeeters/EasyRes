import { TestBed, async, inject } from '@angular/core/testing';

import { MsalGuard } from './msal.guard';
import { MsalService } from '../services/msal.service';
import { HttpClientModule } from '@angular/common/http';

describe('MsalGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
      providers: [MsalGuard, MsalService]
    });
  });

  it('should be created', inject([MsalGuard], (guard: MsalGuard) => {
    expect(guard).toBeTruthy();
  }));
});
