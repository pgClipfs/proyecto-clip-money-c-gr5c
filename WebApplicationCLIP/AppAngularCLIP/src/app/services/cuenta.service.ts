import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Cuenta } from '../clases';

@Injectable({
  providedIn: 'root'
})
export class CuentaService {

  constructor() { }
  
  private cuentas: BehaviorSubject<Cuenta[]>;
  private cuenta: BehaviorSubject<Cuenta>;
  
  /*public obtenerCuenta(cvu:string): Observable<Cuenta>{

  }*/ 

  public obtenerCuenta(cvu:string): Observable<Cuenta>{
   var c= new Cuenta ();

   c.Cvu="00005600"
   c.NombreUsuario="Pepe"
   c.Saldo=4400

   this.cuenta=new BehaviorSubject(c);
   return this.cuenta.asObservable();

  }

  public obtenerCuentasUsuario(nombreDeUsuario: string): Observable<Cuenta[]> {
  
    var cuenta1= new Cuenta();
    var cuenta2= new Cuenta();
    var cuenta3= new Cuenta();

    cuenta1.Cvu="00001235"
    cuenta2.Cvu="00001615"
    cuenta3.Cvu="00006535"
    cuenta1.NombreUsuario="Pepe"
    cuenta2.NombreUsuario="Pepe"
    cuenta3.NombreUsuario="Pepe"
    cuenta1.Saldo=15000
    cuenta2.Saldo=2000
    cuenta3.Saldo=3000
    
    var listaCuentas: Cuenta[] = [];

    listaCuentas.push(cuenta1)
    listaCuentas.push(cuenta2)
    listaCuentas.push(cuenta3)

    this.cuentas= new BehaviorSubject<Cuenta[]>(listaCuentas);

    return this.cuentas.asObservable();

  }

}
