import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PantallaFalloComponent } from './pantalla-fallo.component';

describe('PantallaFalloComponent', () => {
  let component: PantallaFalloComponent;
  let fixture: ComponentFixture<PantallaFalloComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PantallaFalloComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PantallaFalloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
