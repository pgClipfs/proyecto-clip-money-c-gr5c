import { Component, OnInit } from '@angular/core';

import { OperacionesService } from "../../services/operaciones.service"

@Component({
  selector: 'app-operaciones',
  templateUrl: './operaciones.component.html',
  styleUrls: ['./operaciones.component.css']
})
export class OperacionesComponent implements OnInit {

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
  
  abrirSideBar(){
    this.opened = !this.opened;
  }


  ngOnInit(): void {
  }

}
