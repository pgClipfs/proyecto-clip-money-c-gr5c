import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from 'src/app/modelos/usuario';
import { DatosUsuarioService } from 'src/app/services/datos-usuario.service';
import { LoginService } from 'src/app/services/login.service';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RedireccionService } from 'src/app/services/redireccion.service';
import { OperacionService } from 'src/app/services/operacion.service';
import { Cuenta, Operacion } from 'src/app/clases';
import { CuentaService } from 'src/app/services/cuenta.service';
import { flatMap, retry } from 'rxjs/operators';

@Component({
  selector: 'app-pagina-principal',
  templateUrl: './pagina-principal.component.html',
  styleUrls: ['./pagina-principal.component.css']
})
export class PaginaPrincipalComponent implements OnInit {

  usuario: Usuario;
  nombreUsuario: string = "Usuario No Encontrado";

  saldoDolares=0
  saldoPesos = "-";
  opened = false;
  numeroCuenta = "-";
  numeroCuentaDol = "";
  nombreApellido = '- - -';
  Fecha = '14/12/2020';
  Descripcion = 'Ingreso de dinero';
  Monto = '-';
  tipoOperacion = 'Ingr.';


  openLg(contentIngresarDinero) {
    this.modalService.open(contentIngresarDinero, { size: 'lg' });
  }

  abrirSideBar() {
    this.opened = !this.opened;
  }

  cerrar_sesion() {
    this.loginService.logout();
    this.redireccionar.landingPage();
  }


  constructor(private cuentasService: CuentaService, private operacionesService: OperacionService, private modalService: NgbModal, private redireccionar: RedireccionService, private loginService: LoginService, private datosUsuarioService: DatosUsuarioService) { }

  private returnUrl: string;

  operaciones: Operacion[] = [];
  cuentas: Cuenta[];
  cuentaUsuario: Cuenta

  ngOnInit(): void {

    //#region cuentas y operaciones

    this.cuentasService.obtenerCuentasUsuario().subscribe(
      val => {
        this.cuentaUsuario = val[0]
        //console.log(this.cuentaUsuario)
      },
      err => {
        console.log(err)
      },
      () => {

        this.saldoPesos=this.cuentaUsuario.Saldo.toString()
        this.numeroCuenta=this.cuentaUsuario.Cvu
        //console.log(this.cuentaUsuario.Cvu)
        this.operacionesService.getOperacionesCvu(this.cuentaUsuario.Cvu).subscribe(
          ops => {
            this.operaciones = ops;
            console.log(ops)
          },
          err => {
            console.log(err)
          }
        );
      }
    );

    //#endregion 

    //#region datos usuario

    if (!(this.loginService.sesionEstaAbierta())) {
      this.redireccionar.login()
      console.log("el usuario debe loguearse antes de ver la pagina principal")
    }

    this.datosUsuarioService.obtenerDatosUsuario().subscribe(
      user => {
        this.usuario = user;
        this.nombreUsuario = this.usuario.Nombre + " " + this.usuario.Apellido;
      },
      err => {
        console.log("no se encontro el usuario (?");
      }
    );

    //#endregion
  }

}
