import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  Validators,
  FormGroup,
  FormsModule,
} from '@angular/forms';
import { Usuario } from 'src/app/modelos/usuario';
import { EdicionPerfilService } from 'src/app/services/edicion-perfil.service';
import { DatosUsuarioService } from 'src/app/services/datos-usuario.service';
import { Cuenta } from 'src/app/clases';
import { CuentaService } from 'src/app/services/cuenta.service';
import { RedireccionService } from 'src/app/services/redireccion.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-pantalla-edicion-perfil',
  templateUrl: './pantalla-edicion-perfil.component.html',
  styleUrls: ['./pantalla-edicion-perfil.component.css'],
})
export class PantallaEdicionPerfilComponent implements OnInit {
  usuario: Usuario;
  fgroup: FormGroup;
  nombreUsuario: string = 'Usuario No Encontrado';
  apellidoUsuario: string;
  cuentaUsuario: Cuenta;

  constructor(
    private fb: FormBuilder,
    private datosUsuarioService: DatosUsuarioService,
    private cuentasService: CuentaService,
    private redireccionar: RedireccionService,
    private loginService: LoginService
  ) {}

  ngOnInit(): void {
    this.cuentasService.obtenerCuentasUsuario().subscribe(
      (val) => {
        this.cuentaUsuario = val[0];
      },
      (err) => {
        this.loginService.logout();
        this.redireccionar.landingPage();
      },
      () => {
        this.obtenerDatosUsuario();
      }
    );

    this.fgroup = this.fb.group({
      Nombre: [
        this.nombreUsuario,
        [
          Validators.required,
          Validators.maxLength(55),
          Validators.pattern("^[a-zA-Z' ]+$"),
        ],
      ],
      Apellido: [
        this.apellidoUsuario,
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
      //Necesario traer los datos actuales del usuario antes de usar el servicio EdicionPerfil
    }
  }

  obtenerDatosUsuario() {
    this.datosUsuarioService.obtenerDatosUsuario().subscribe(
      (user) => {
        this.usuario = user;
        this.nombreUsuario = this.usuario.Nombre;
        this.apellidoUsuario = this.usuario.Apellido;
      },
      (err) => {
        console.log('no se encontro el usuario (?');
      }
    );
  }
}
