import { Component, OnInit } from '@angular/core';

import { OperacionService } from "../../services/operacion.service"

@Component({
  selector: 'app-operaciones',
  templateUrl: './operaciones.component.html',
  styleUrls: ['./operaciones.component.css']
})
export class OperacionesComponent implements OnInit {

  operaciones:any[] = [];

  constructor(private _servicio: OperacionService) { 
    
    //this.operaciones = _servicio.getOperacionesCvu();
  }

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
