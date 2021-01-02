import { Component, OnInit ,ViewEncapsulation} from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LoginService } from 'src/app/services/login.service';
import { RedireccionService } from 'src/app/services/redireccion.service';

@Component({
  selector: 'app-navbar-lateral',
  templateUrl: './navbar-lateral.component.html',
  styleUrls: ['./navbar-lateral.component.css']
})
export class NavbarLateralComponent implements OnInit {

  closeResult: string;

  constructor(private redireccionar: RedireccionService, private modalService: NgbModal, private loginservice: LoginService) { }

  nombreUsuario = 'juancuello98';
  saldoPesos = 2555;
  opened = false;
  numeroCuenta = 201241535212312;
  numeroCuentaDol = 20124134534512;
  nombreApellido = 'JUAN CRUZ CUELLO';
  Fecha = '14/12/2020';
  Descripcion = 'Ingreso de dinero';
  Monto= '$2500';
  tipoOperacion = 'Ingr.';

  openLg(content) {
    this.modalService.open(content, { size: 'lg' });
  }

  abrirSideBar(){
    this.opened = !this.opened;
  }

  cerrarSesion(){
    this.loginservice.logout();
    this.redireccionar.landingPage()
  }

  ngOnInit(): void {
    if(! this.loginservice.sesionEstaAbierta()){
      this.redireccionar.login();
    }
  }

}
