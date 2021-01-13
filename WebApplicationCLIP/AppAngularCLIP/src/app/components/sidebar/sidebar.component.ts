import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { RedireccionService } from 'src/app/services/redireccion.service';
import { DatosUsuarioService } from 'src/app/services/datos-usuario.service';
import { Usuario } from 'src/app/modelos/usuario';
import { Cuenta } from 'src/app/clases';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  opened = false;
  nombreUsuario: string = "Usuario No Encontrado";
  usuario : Usuario;
  cuentaUsuario: Cuenta;

  isGiroAlDescubierto : boolean = false;
  isDashboard : boolean = true;
  isIngresoEgreso : boolean = false;
  isTransferencia : boolean = false;

  constructor(private redireccionar: RedireccionService, private loginService: LoginService, private datosUsuarioService: DatosUsuarioService) { }

  ngOnInit(): void {
    this.obtenerDatosUsuario();
  }

  cerrar_sesion() {
    this.loginService.logout();
    this.redireccionar.landingPage();
  }


  abrirSideBar() {
    this.opened = !this.opened;
  }

  public obtenerDatosUsuario() {

    this.datosUsuarioService.obtenerDatosUsuario().subscribe(
      user => {
        this.usuario = user;
        this.nombreUsuario = this.usuario.NombreDeUsuario;
      },
      err => {
        console.log("no se encontro el usuario (?");
      }
    );

    //#endregion
  }

  routeDashboard(){
    this.isDashboard = true;
    this.isGiroAlDescubierto = false;
    this.isIngresoEgreso = false;
    this.isTransferencia = false;
  }

  routeIngresoEgreso(){
    this.isDashboard = false;
    this.isGiroAlDescubierto = false;
    this.isIngresoEgreso = true;
    this.isTransferencia = false;
  }

  routeTransferencia(){
    this.isDashboard = false;
    this.isGiroAlDescubierto = false;
    this.isIngresoEgreso = false;
    this.isTransferencia = true;
  }

  routeGiroAlDescubierto(){
    this.isDashboard = false;
    this.isGiroAlDescubierto = true;
    this.isIngresoEgreso = false;
    this.isTransferencia = false;
  }
}
