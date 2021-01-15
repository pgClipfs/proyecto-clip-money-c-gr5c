import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  Validators,
  FormGroup,
  FormsModule,
} from '@angular/forms';
import { Usuario } from 'src/app/modelos/usuario';
import { EdicionPerfilService } from 'src/app/services/edicion-perfil.service';

@Component({
  selector: 'app-pantalla-edicion-perfil',
  templateUrl: './pantalla-edicion-perfil.component.html',
  styleUrls: ['./pantalla-edicion-perfil.component.css'],
})
export class PantallaEdicionPerfilComponent implements OnInit {
  fgroup: FormGroup;
  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.fgroup = this.fb.group({
      Nombre: [
        '',
        [
          Validators.required,
          Validators.maxLength(55),
          Validators.pattern("^[a-zA-Z' ]+$"),
        ],
      ],
      Apellido: [
        '',
        [
          Validators.required,
          Validators.maxLength(55),
          Validators.pattern("^[a-zA-Z' ]+$"),
        ],
      ],
      Domicilio: ['', [Validators.required, Validators.maxLength(55)]],
      Email: [
        '',
        [Validators.required, Validators.maxLength(55), Validators.email],
      ],
      Telefono: ['', [Validators.pattern('^[0-9]{1,20}$')]],
    });
  }

  actualizar() {
    if (this.fgroup.valid) {
      //Necesario crear el servicio para traer los datos actuales del usuario antes de continuar
    }
  }
}
