import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { HttpClientModule } from '@angular/common/http';
import { Usuario } from '../modelos/usuario';
import { Operacion } from '../clases';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class OperacionService {

  private urlApi = "http://localhost:59642/api/"; //linea para hacer pruebas


  constructor(private http: HttpClient, private loginService: LoginService) { }

  public getOperacionesCvu(cvu: string): Observable<Operacion[]> {

    //no es lo ideal pasar los parametros asi, pero no logre que funcione de otra forma
    return this.http.post<any>(this.urlApi + 'get/operaciones?cvu='+cvu, { })
      .pipe(
        //retry(2), //esto es para decirle cuantas veces lo tiene que intentar antes de tirar error :o
        catchError(err => {
          return err;
        }),
        map(ops => {
          ops.forEach(op => {
            switch(op.TipoOperacion){
              case 1:{
                op.Tipo="Transferencia";
                break;
              }
              case 2:{
                op.Tipo="Depósito";
                break;
              }
              case 3:{
                op.Tipo="Extracción";
                break;
              }
              case 4:{
                op.Tipo="Giro al Descubierto";
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
