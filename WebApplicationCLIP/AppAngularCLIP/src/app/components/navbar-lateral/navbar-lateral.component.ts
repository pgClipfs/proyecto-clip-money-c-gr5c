import { Component, OnInit ,ViewEncapsulation} from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-navbar-lateral',
  templateUrl: './navbar-lateral.component.html',
  styleUrls: ['./navbar-lateral.component.css']
})
export class NavbarLateralComponent implements OnInit {

  closeResult: string;

  constructor(private modalService: NgbModal) { }

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

  ngOnInit(): void {
  }

}
