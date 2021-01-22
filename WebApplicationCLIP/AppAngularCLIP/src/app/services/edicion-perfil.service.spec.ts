import { TestBed } from '@angular/core/testing';

import { EdicionPerfilService } from './edicion-perfil.service';

describe('EdicionPerfilService', () => {
  let service: EdicionPerfilService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EdicionPerfilService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
