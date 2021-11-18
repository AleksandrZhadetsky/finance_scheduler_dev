import { TestBed } from '@angular/core/testing';

import { PurchaseManagementService } from './purchase-management.service';

describe('PurchaseManagementService', () => {
  let service: PurchaseManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PurchaseManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
