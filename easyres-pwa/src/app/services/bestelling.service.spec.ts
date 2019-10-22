import { TestBed } from '@angular/core/testing';

import { BestellingService } from './bestelling.service';
import { HttpClientModule } from '@angular/common/http';

describe('BestellingService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientModule]
  }));

  it('should be created', () => {
    const service: BestellingService = TestBed.get(BestellingService);
    expect(service).toBeTruthy();
  });
});
