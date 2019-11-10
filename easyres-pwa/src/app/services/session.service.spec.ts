import { TestBed } from '@angular/core/testing';

import { SessionService } from './session.service';
import { HttpClientModule } from '@angular/common/http';

describe('SessionService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientModule]
  }));

  it('should be created', () => {
    const service: SessionService = TestBed.get(SessionService);
    expect(service).toBeTruthy();
  });
});
