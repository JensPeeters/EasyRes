import { TestBed, async, inject } from '@angular/core/testing';

import { MsalGuard } from './msal.guard';
import { MsalService } from '../services/msal.service';

describe('MsalGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MsalGuard, MsalService]
    });
  });

  it('should be created', inject([MsalGuard], (guard: MsalGuard) => {
    expect(guard).toBeTruthy();
  }));
});
