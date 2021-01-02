import { TestBed } from '@angular/core/testing';

import { RedireccionService } from './redireccion.service';

describe('RedireccionService', () => {
  let service: RedireccionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RedireccionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
