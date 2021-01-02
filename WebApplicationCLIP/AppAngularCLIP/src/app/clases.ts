export class Operacion {
  IdOperacion: string;
  Monto: number;
  Fecha: Date;
  Tipo: string;
}

export class Sesion {
  NombreUsuario: string;
  Token: string;
}

export class Cuenta{
  Saldo: number;
  Cvu: string;
  NombreUsuario: string;
}
