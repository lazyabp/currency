import { TestBed } from '@angular/core/testing';

import { CurrencyKitService } from './currency-kit.service';

describe('CurrencyKitService', () => {
  let service: CurrencyKitService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CurrencyKitService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
