import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { foodGuard } from './food-guard';

describe('foodGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => foodGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
