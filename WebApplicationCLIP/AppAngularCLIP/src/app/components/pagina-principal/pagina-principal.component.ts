import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from 'src/app/modelos/usuario';
import { DatosUsuarioService } from 'src/app/services/datos-usuario.service';
import { LoginService } from 'src/app/services/login.service';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-pagina-principal',
  templateUrl: './pagina-principal.component.html',
  styleUrls: ['./pagina-principal.component.css']
})
export class PaginaPrincipalComponent implements OnInit {

  usuario:Usuario;
  nombreUsuario: string = "Usuario generico";


  saldoPesos = 2555;
  opened = false;
  numeroCuenta = 201241535212312;
  numeroCuentaDol = 20124134534512;
  nombreApellido = 'Juan Cruz Cuello';
  Fecha = '14/12/2020';
  Descripcion = 'Ingreso de dinero';
  Monto= '$2500';
  tipoOperacion = 'Ingr.';


  openLg(contentIngresarDinero) {
    this.modalService.open(contentIngresarDinero, { size: 'lg' });
  }

  abrirSideBar(){
    this.opened = !this.opened;
  }

  cerrar_sesion(){
    this.loginService.logout();
    //location.reload();

    var returnUrl= this.route.snapshot.queryParams.returnUrl || '/';

    console.log("Sesion cerrada")
    this.router.navigate([returnUrl]);
  }


  constructor(private modalService: NgbModal, private route: ActivatedRoute, private router: Router, private loginService: LoginService, private datosUsuarioService: DatosUsuarioService) { }

  private returnUrl: string;

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/login';
    if(!(this.loginService.sesionEstaAbierta)){
      this.router.navigate([this.returnUrl]);
      console.log("el usuario debe loguearse antes de ver la pagina principal")
  }
  this.datosUsuarioService.obtenerDatosUsuario().subscribe(
    user => {
     //parece que todo bien
  //   console.log(user);
     this.usuario=user;
     this.nombreUsuario= this.usuario.Nombre + " " + this.usuario.Apellido;
    },
    err => {
      console.log("no se encontro el usuario (?");
    }
);

  }

}
