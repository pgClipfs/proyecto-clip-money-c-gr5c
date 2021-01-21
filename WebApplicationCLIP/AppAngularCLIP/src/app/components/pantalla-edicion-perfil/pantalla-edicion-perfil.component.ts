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
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-pantalla-edicion-perfil',
  templateUrl: './pantalla-edicion-perfil.component.html',
  styleUrls: ['./pantalla-edicion-perfil.component.css'],
})
export class PantallaEdicionPerfilComponent implements OnInit {
  usuario: Usuario;
  fgroup: FormGroup;
  nombreUsuario: string = 'prueba';
  apellidoUsuario: string;
  cuentaUsuario: Cuenta;

  constructor(
    private fb: FormBuilder,
    private datosUsuarioService: DatosUsuarioService,
    private edicionPerfilService: EdicionPerfilService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.obtenerDatosUsuario();
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

  errorRegistro = false;
  mensajeError = 'error';

  actualizar() {
    let usuario = new Usuario();

    usuario.Apellido = this.fgroup.value.Apellido;
    usuario.Nombre = this.fgroup.value.Nombre;
    usuario.Email = this.fgroup.value.Email;
    usuario.Domicilio = this.fgroup.value.Domicilio;
    usuario.Telefono = this.fgroup.value.Telefono;
    this.errorRegistro = false;

    // console.log(usuario.Nombre);
    // console.log(usuario.Nombre);
    // console.log(usuario.Apellido);
    // console.log(usuario.Domicilio);
    // console.log(usuario.Email);
    // console.log(usuario.Telefono);

    this.edicionPerfilService.updateUser(usuario).subscribe(
      () => {
        console.log('Update Exitoso');
        var returnUrl = this.route.snapshot.queryParams.returnUrl || '/exito';
        this.router.navigate([returnUrl]);
      },
      (err) => {
        this.errorRegistro = true;
        this.mensajeError = err;
        console.log('error en el registro');
        console.log(err);
      }
    );
  }

  obtenerDatosUsuario() {
    this.datosUsuarioService.obtenerDatosUsuario().subscribe(
      (user) => {
        this.usuario = user;

        this.nombreUsuario = this.usuario.Nombre;
        this.apellidoUsuario = this.usuario.Apellido;
        this.campoNombreUsuario.setValue(this.usuario.Nombre);
        this.campoApellido.setValue(this.usuario.Apellido);
        this.campoDomicilio.setValue(this.usuario.Domicilio);
        this.campoEmail.setValue(this.usuario.Email);
        this.campoTelefono.setValue(this.usuario.Telefono);
      },
      (err) => {
        console.log('no se encontro el usuario (?');
      }
    );
  }

  get campoNombreUsuario() {
    return this.fgroup.get('Nombre');
  }

  get campoApellido() {
    return this.fgroup.get('Apellido');
  }

  get campoDomicilio() {
    return this.fgroup.get('Domicilio');
  }

  get campoTelefono() {
    return this.fgroup.get('Telefono');
  }

  get campoEmail() {
    return this.fgroup.get('Email');
  }
}
