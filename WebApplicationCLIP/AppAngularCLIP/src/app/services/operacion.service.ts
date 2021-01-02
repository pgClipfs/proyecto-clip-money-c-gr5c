import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { HttpClientModule } from '@angular/common/http';
import { Usuario } from '../modelos/usuario';
import { Operacion } from '../clases';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';
import { LoginService } from './login.service';
import { Sesion } from '../clases';

@Injectable({
  providedIn: 'root'
})
export class OperacionService {

  private urlApi = "http://localhost:59642/api/"; //linea para hacer pruebas


  constructor(private http: HttpClient, private loginService: LoginService) { }

  public realizarExtraccion(cvu: string, monto: number): Observable<any> {
    var dir = "post/extraccion";
    return this.postOperacion(cvu, monto, dir)
  }

  public realizarDeposito(cvu: string, monto: number): Observable<any> {
    var dir = "post/deposito";
    return this.postOperacion(cvu, monto, dir)
  }

  private postOperacion(Cvu: string, Monto: number, dir: string): Observable<any> {

    var SesionDeUsuario = this.loginService.obtenerSesionActual

    return this.http.post<any>(this.urlApi + dir, { Cvu, Monto, SesionDeUsuario })
      .pipe(
        catchError(err => {
          throw err;
          //para leer el mensaje del error, hacer err.error
          })
          ,map( asd => {
             return asd;
             //se podria devolver la fecha e id de la operacion, y mostrarla en una pantalla de confirmacion
             })
      );
  }

  public getOperacionesCvu(Cvu: string): Observable<Operacion[]> {

    var SesionDeUsuario= this.loginService.obtenerSesionActual;

    //no es lo ideal pasar los parametros asi, pero no logre que funcione de otra forma
    return this.http.post<any>(this.urlApi + 'get/operaciones', {Cvu,SesionDeUsuario})
      .pipe(
        //retry(2), //esto es para decirle cuantas veces lo tiene que intentar antes de tirar error :o
        catchError(err => {
          console.log("err"+err)
          throw err;
        }),
        map(ops => {
          ops.forEach(op => {
            switch (op.TipoOperacion) {
              case 1: {
                op.Tipo = "Transferencia";
                break;
              }
              case 2: {
                op.Tipo = "Depósito";
                break;
              }
              case 3: {
                op.Tipo = "Extracción";
                break;
              }
              case 4: {
                op.Tipo = "Giro al Descubierto";
                break;
              }
            }
          });

          return ops;
        }
        )
      );
  }
}
