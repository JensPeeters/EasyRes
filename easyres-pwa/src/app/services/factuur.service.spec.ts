import { TestBed } from '@angular/core/testing';

import { FactuurService } from './factuur.service';
import { HttpClientModule } from '@angular/common/http';

describe('FactuurService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientModule]
  }));

  it('should be created', () => {
    const service: FactuurService = TestBed.get(FactuurService);
    expect(service).toBeTruthy();
  });
});
