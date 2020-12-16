import { Component, OnInit } from '@angular/core';

import { OperacionesService } from "../../services/operaciones.service"

@Component({
  selector: 'app-operaciones',
  templateUrl: './operaciones.component.html',
  styleUrls: ['./operaciones.component.css']
})
export class OperacionesComponent implements OnInit {
  operacionesService: any;

  constructor(public service: OperacionesService) { }

  ngOnInit() {
    this.operacionesService.getOperaciones().suscribe(data => {
      this.operacionesService = data;
    });
  }

}
