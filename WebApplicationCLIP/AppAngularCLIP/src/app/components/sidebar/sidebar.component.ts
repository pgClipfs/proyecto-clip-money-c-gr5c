import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { RedireccionService } from 'src/app/services/redireccion.service';
import { DatosUsuarioService } from 'src/app/services/datos-usuario.service';
import { Usuario } from 'src/app/modelos/usuario';
import { Cuenta, Ventana } from 'src/app/clases';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})

export class SidebarComponent implements OnInit {
  
  ventanaActual: Ventana = Ventana.Dashboard;
  ventana =Ventana; //esta linea es necesaria porque el html no conoce a la clase "Modo", por eso hay que declarar una variable en el ts que sirva de "intermediario"
  
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

  routeTo(vent: Ventana){
    this.ventanaActual=vent
    this.opened = false;
    console.log("viendo "+vent)
    console.log(vent)
  }

  routeDashboard(){
    this.ventanaActual=Ventana.Dashboard
    this.opened = false;
  }
  
  routeIngresoEgreso(){
    this.ventanaActual=Ventana.IngresosEgresos
    this.opened = false;
  }
  
  routeTransferencia(){
    this.ventanaActual=Ventana.Transferencia
    this.opened = false;
  }
  
  routeGiroAlDescubierto(){
    this.ventanaActual=Ventana.Giro
    this.opened = false;
  }
}

