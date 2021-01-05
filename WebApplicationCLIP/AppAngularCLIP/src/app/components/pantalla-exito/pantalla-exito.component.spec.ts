import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PantallaExitoComponent } from './pantalla-exito.component';

describe('PantallaExitoComponent', () => {
  let component: PantallaExitoComponent;
  let fixture: ComponentFixture<PantallaExitoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PantallaExitoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PantallaExitoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
