import { Usuario } from './modelos/usuario';

export class Operacion {
  IdOperacion: string;
  Monto: number;
  Fecha: Date;
  Tipo: string;
}

export class Transferencia {
  CvuOrigen: string;
  CvuDestino: string;
  Destinatario: Usuario;
  Remitente : Usuario;

  Fecha: Date;
  Monto: number;
  IdOperacion: string;
  
  NumeroTransferencia: string;
  Categoria: string;
  Referencia: string;

  Enviada: boolean;
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
  EdicionPerfil,
}

export enum EstadoBusqueda {
  ResultadoExitoso,
  Error,
  Buscando,
  Nada,
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
