import { TestBed } from '@angular/core/testing';

import { BestellingService } from './bestelling.service';
import { HttpClientModule } from '@angular/common/http';

describe('BestellingService', () => {
  //let service: BestellingService;
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientModule]
  }));
  //service = TestBed.get(BestellingService);

  it('should be created', () => {
    const service: BestellingService = TestBed.get(BestellingService);
    expect(service).toBeTruthy();
  });

  it('should clear the bestelling', () => {
    const service: BestellingService = TestBed.get(BestellingService);
    service.bestelling = {
      prijs: 50,
      tafelNr: 20,
      dranken: [{prijs: 5, aantal:2},{prijs: 2, aantal:3}],
      etenswaren: [{prijs: 5, aantal:2},{prijs: 2, aantal:3}]
    };
    service.ClearBestelling()
    expect(service.bestelling).toEqual({
      prijs: 0,
      tafelNr: 0,
      dranken: [],
      etenswaren: []});
  });

  it('should return the total price', () => {
    const service: BestellingService = TestBed.get(BestellingService);
    service.bestelling = {
      prijs: 0,
      tafelNr: 20,
      dranken: [{prijs: 5, aantal:2},{prijs: 2, aantal:3}],
      etenswaren: [{prijs: 5, aantal:2},{prijs: 2, aantal:3}]
    };
    expect(service.Bestelling.prijs).toBe(32);
  });

});
