import { Usuario } from './modelos/usuario';

export class Operacion {
  IdOperacion: string;
  Monto: number;
  Fecha: Date;
  Tipo: string;
}

export class Sesion {
  NombreDeUsuario: string;
  Token: string;
}

export class Cuenta {
  Saldo: number;
  Cvu: string;
  NombreUsuario: string;
  datosUsuario: Usuario;
}

//enum ventana actual
export enum Ventana {
  IngresosEgresos,
  Dashboard,
  Transferencia,
  Giro,
  PagarServicios,
}

export enum CategoriaTransferencia {
  Varios,
  Alquiler,
  AportesDeCapital,
  Expensas,
  Factura,
  Haberes,
  Honorarios,
  Prestamo,
  Seguro,
  Cuota,
}
