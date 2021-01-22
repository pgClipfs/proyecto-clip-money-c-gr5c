import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PantallaEdicionPerfilComponent } from './pantalla-edicion-perfil.component';

describe('PantallaEdicionPerfilComponent', () => {
  let component: PantallaEdicionPerfilComponent;
  let fixture: ComponentFixture<PantallaEdicionPerfilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PantallaEdicionPerfilComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PantallaEdicionPerfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
