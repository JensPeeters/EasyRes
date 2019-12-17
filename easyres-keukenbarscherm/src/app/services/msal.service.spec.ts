import { TestBed } from '@angular/core/testing';

import { MsalService } from './msal.service';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

describe('MsalService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [ HttpClientModule, RouterModule.forRoot([]) ]
  }));

  it('should be created', () => {
    const service: MsalService = TestBed.get(MsalService);
    expect(service).toBeTruthy();
  });
});
