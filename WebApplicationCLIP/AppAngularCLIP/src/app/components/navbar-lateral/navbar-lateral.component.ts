import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar-lateral',
  templateUrl: './navbar-lateral.component.html',
  styleUrls: ['./navbar-lateral.component.css']
})
export class NavbarLateralComponent implements OnInit {

  constructor() { }

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
  sidebarPrincipal : boolean = true;
  sidebarTransferencia : boolean = false;
  sidebarIngreso : boolean = false;

  habilitarPrincipal(){
    this.sidebarPrincipal = true;
    this.sidebarTransferencia = false;
    this.sidebarIngreso = false;
  }

  habilitarTransferir(){
    this.sidebarPrincipal = false;
    this.sidebarTransferencia = true;
    this.sidebarIngreso = false;
  }

  abrirSideBar(){
    this.opened = !this.opened;
  }

  ngOnInit(): void {
  }

}
