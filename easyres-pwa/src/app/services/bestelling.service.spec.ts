import { TestBed } from '@angular/core/testing';

import { BestellingService } from './bestelling.service';

describe('BestellingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BestellingService = TestBed.get(BestellingService);
    expect(service).toBeTruthy();
  });
});
