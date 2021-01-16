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
export class TransferenciasService {

  constructor(private http: HttpClient, private loginService : LoginService) { }

  private urlApi = "http://localhost:59642/api/"; //linea para hacer pruebas

  public realizarTransferencia (CvuDestino:String, Monto: number, Referencia : String, CvuOrigen: String, Categoria : String): Observable<any> {
    var dir = 'post/transferir';
    var SesionDeUsuario = this.loginService.obtenerSesionActual;
    return this.http.post<any>(this.urlApi + dir, {CvuDestino,Monto,Referencia,CvuOrigen,SesionDeUsuario, Categoria})
    .pipe(
      catchError(err => {
        throw err.error;
        ;

      }),
      map(
        data => {
          return data
        }
      )
    )
  }

  public obtenerTransferencias (Cvu : String) : Observable<any>{
    var dir = 'get/transferencias';
    var SesionDeUsuario = this.loginService.obtenerSesionActual;
    return this.http.post<any>(this.urlApi + dir, {Cvu,SesionDeUsuario})
    .pipe(
      catchError(err => {
        throw err.error;

      }),
      map(
        data => {
          return data;
        }
      )
    )

    }

  }


