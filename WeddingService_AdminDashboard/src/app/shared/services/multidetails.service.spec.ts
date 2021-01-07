import { TestBed } from '@angular/core/testing';

import { MultidetailsService } from './multidetails.service';

describe('MultidetailsService', () => {
  let service: MultidetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MultidetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
