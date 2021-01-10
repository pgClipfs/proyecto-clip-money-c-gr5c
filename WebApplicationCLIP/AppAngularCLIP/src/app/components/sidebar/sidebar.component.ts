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
  constructor(private redireccionar: RedireccionService, private loginService: LoginService, private datosUsuarioService: DatosUsuarioService) { }

  ngOnInit(): void {
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
        this.cuentaUsuario.NombreUsuario = user.NombreDeUsuario
        this.nombreUsuario = this.usuario.Nombre + " " + this.usuario.Apellido;
      },
      err => {
        console.log("no se encontro el usuario (?");
      }
    );

    //#endregion
  }
}
