import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Cuenta } from '../clases';
import { HttpClient, HttpParams } from "@angular/common/http";
import { HttpClientModule } from '@angular/common/http';
import { Usuario } from '../modelos/usuario';
import { Operacion } from '../clases';
import { map, retry, catchError } from 'rxjs/operators';
import { LoginService } from './login.service';
import { Sesion } from '../clases';


@Injectable({
  providedIn: 'root'
})
export class CuentaService {

  constructor(private http: HttpClient, private loginService: LoginService) { }

  private urlApi = "http://localhost:59642/api/"; //linea para hacer pruebas

  public obtenerCuentaOtroUsuario(Cvu: string): Observable<Cuenta> {

    return this.http.post<any>(this.urlApi + 'get/datosCuentaTerceros', {Cvu})
      .pipe(
        //retry(2), //esto es para decirle cuantas veces lo tiene que intentar antes de tirar error :o
        catchError(err => {
          //console.log("err"+err)
          throw err;
        }),
        map(cta => {
  
          var cuenta: Cuenta

            cuenta = new Cuenta()
            cuenta.Cvu = cta.Cvu
            cuenta.Saldo = cta.Saldo
            cuenta.datosUsuario=cta.Usuario;
 
          return cuenta;
        }
        )
      );
  }

  public obtenerCuenta(Cvu: string): Observable<Cuenta> {

    var SesionDeUsuario = this.loginService.obtenerSesionActual

    return this.http.post<any>(this.urlApi + 'get/datoscuenta', {Cvu,SesionDeUsuario})
      .pipe(
        //retry(2), //esto es para decirle cuantas veces lo tiene que intentar antes de tirar error :o
        catchError(err => {
          //console.log("err"+err)
          throw err;
        }),
        map(cta => {
  
          var cuenta: Cuenta

            cuenta = new Cuenta()
            cuenta.Cvu = cta.Cvu
            cuenta.Saldo = cta.Saldo
            cuenta.NombreUsuario = SesionDeUsuario.NombreDeUsuario
            cuenta.datosUsuario=cta.Usuario;
 
          return cuenta;
        }
        )
      );
  }

  public obtenerCuentasUsuario(): Observable<Cuenta[]> {

    var sesion = this.loginService.obtenerSesionActual

    return this.http.post<any>(this.urlApi + 'get/cuentasusuario', sesion)
      .pipe(
        //retry(2), //esto es para decirle cuantas veces lo tiene que intentar antes de tirar error :o
        catchError(err => {
          //console.log("err"+err)
          throw err;
        }),
        map(ctas => {

          var cuentas: Cuenta[] = []
          var cuenta: Cuenta


          ctas.forEach(cta => {

            cuenta = new Cuenta()
            cuenta.Cvu = cta.Cvu
            cuenta.Saldo = cta.Saldo
            cuenta.NombreUsuario = sesion.NombreDeUsuario
            cuentas.push(cuenta)
          });

          return cuentas;
        }
        )
      );
    /* var cuenta1= new Cuenta();
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
     return this.cuentas.asObservable();*/


  }

}
