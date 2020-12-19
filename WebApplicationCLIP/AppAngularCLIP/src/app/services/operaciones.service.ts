import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class OperacionesService {
  operaciones:any[] = [
  {
    nombreUsuario: 'juancuello98',
    saldoPesos: 2555,
    opened : false,
    numeroCuenta: 201241535212312,
    numeroCuentaDol: 20124134534512,
    nombreApellido: 'JUAN CRUZ CUELLO',
    Fecha: '14/12/2020',
    Descripcion: 'Ingreso de dinero',
    Monto: '$2500',
    tipoOperacion: 'Ingr.',
  },
  {
    nombreUsuario: 'juancuello98',
    saldoPesos: 2555,
    opened : false,
    numeroCuenta: 201241535212312,
    numeroCuentaDol: 20124134534512,
    nombreApellido: 'JUAN CRUZ CUELLO',
    Fecha: '14/12/2020',
    Descripcion: 'Ingreso de dinero',
    Monto: '$2500',
    tipoOperacion: 'Ingr.',
  },
  {
    nombreUsuario: 'juancuello98',
    saldoPesos: 2555,
    opened : false,
    numeroCuenta: 201241535212312,
    numeroCuentaDol: 20124134534512,
    nombreApellido: 'JUAN CRUZ CUELLO',
    Fecha: '14/12/2020',
    Descripcion: 'Ingreso de dinero',
    Monto: '$2500',
    tipoOperacion: 'Ingr.',
  },
  {
    nombreUsuario: 'juancuello98',
    saldoPesos: 2555,
    opened : false,
    numeroCuenta: 201241535212312,
    numeroCuentaDol: 20124134534512,
    nombreApellido: 'JUAN CRUZ CUELLO',
    Fecha: '14/12/2020',
    Descripcion: 'Ingreso de dinero',
    Monto: '$2500',
    tipoOperacion: 'Ingr.',
  },
  {
    nombreUsuario: 'juancuello98',
    saldoPesos: 2555,
    opened : false,
    numeroCuenta: 201241535212312,
    numeroCuentaDol: 20124134534512,
    nombreApellido: 'JUAN CRUZ CUELLO',
    Fecha: '14/12/2020',
    Descripcion: 'Ingreso de dinero',
    Monto: '$2500',
    tipoOperacion: 'Ingr.',
  },
  {
    nombreUsuario: 'juancuello98',
    saldoPesos: 2555,
    opened : false,
    numeroCuenta: 201241535212312,
    numeroCuentaDol: 20124134534512,
    nombreApellido: 'JUAN CRUZ CUELLO',
    Fecha: '14/12/2020',
    Descripcion: 'Ingreso de dinero',
    Monto: '$2500',
    tipoOperacion: 'Ingr.',
  },
  {
    nombreUsuario: 'juancuello98',
    saldoPesos: 2555,
    opened : false,
    numeroCuenta: 201241535212312,
    numeroCuentaDol: 20124134534512,
    nombreApellido: 'JUAN CRUZ CUELLO',
    Fecha: '14/12/2020',
    Descripcion: 'Ingreso de dinero',
    Monto: '$2500',
    tipoOperacion: 'Ingr.',
  },
  {
    nombreUsuario: 'juancuello98',
    saldoPesos: 2555,
    opened : false,
    numeroCuenta: 201241535212312,
    numeroCuentaDol: 20124134534512,
    nombreApellido: 'JUAN CRUZ CUELLO',
    Fecha: '14/12/2020',
    Descripcion: 'Ingreso de dinero',
    Monto: '$2500',
    tipoOperacion: 'Ingr.',
  },
  {
    nombreUsuario: 'juancuello98',
    saldoPesos: 2555,
    opened : false,
    numeroCuenta: 201241535212312,
    numeroCuentaDol: 20124134534512,
    nombreApellido: 'JUAN CRUZ CUELLO',
    Fecha: '14/12/2020',
    Descripcion: 'Ingreso de dinero',
    Monto: '$2500',
    tipoOperacion: 'Ingr.',
  },
  {
    nombreUsuario: 'juancuello98',
    saldoPesos: 2555,
    opened : false,
    numeroCuenta: 201241535212312,
    numeroCuentaDol: 20124134534512,
    nombreApellido: 'JUAN CRUZ CUELLO',
    Fecha: '14/12/2020',
    Descripcion: 'Ingreso de dinero',
    Monto: '$2500',
    tipoOperacion: 'Ingr.',
  },

  {
    nombreUsuario: 'juancuello98',
    saldoPesos: 2555,
    opened : false,
    numeroCuenta: 201241535212312,
    numeroCuentaDol: 20124134534512,
    nombreApellido: 'JUAN CRUZ CUELLO',
    Fecha: '14/12/2020',
    Descripcion: 'Ingreso de dinero',
    Monto: '$2500',
    tipoOperacion: 'Ingr.',
  }
  
  ]

  constructor() { 
    console.log('Funcionando servicio')
  }

  obtenerOperaciones(){
    return this.operaciones
  }

  
}
