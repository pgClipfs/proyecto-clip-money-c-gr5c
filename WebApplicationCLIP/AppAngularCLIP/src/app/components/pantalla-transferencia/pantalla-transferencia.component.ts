import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pantalla-transferencia',
  templateUrl: './pantalla-transferencia.component.html',
  styleUrls: ['./pantalla-transferencia.component.css']
})
export class PantallaTransferenciaComponent implements OnInit {

  constructor() { }

  saldoTransferencia : number = 2500;

  ngOnInit(): void {
  }

}
