import { TestBed } from '@angular/core/testing';

import { MulticodesService } from './multicodes.service';

describe('MulticodesService', () => {
  let service: MulticodesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MulticodesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
