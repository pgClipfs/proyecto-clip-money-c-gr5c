import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Cuenta, Transferencia } from '../clases';
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

          var lista: Transferencia[]=[]

          data.forEach(e => {
            var t = new Transferencia;
            t.Fecha = e.Fecha;
            t.Monto=e.Monto;
            t.IdOperacion=e.IdOperacion;
            
            t.CvuDestino=e.CuentaDestino.Cvu;
            t.CvuOrigen=e.Cuenta.Cvu;
            t.Destinatario=e.CuentaDestino.Usuario;
            t.Remitente=e.Cuenta.Usuario;
            
            t.NumeroTransferencia = e.NumeroTransferencia;
            t.Referencia=e.ReferenciaDestino 

            t.Enviada=false;

            switch (e.Categoria) {
              case 0: {
                t.Categoria="Varios"
                break;
              }
              case 1: {
                t.Categoria="Alquiler"
                break;
              }
              case 2: {
                t.Categoria="Aportes De Capital"
                break;
              }
              case 3: {
                t.Categoria="Expensas"
                break;
              }
              case 4: {
                t.Categoria="Factura"
                break;
              }
              case 5: {
                t.Categoria="Haberes"
                break;
              }
              case 6: {
                t.Categoria="Honorarios"
                break;
              }
              case 7: {
                t.Categoria="Prestamo"
                break;
              }
              case 8: {
                t.Categoria="Seguro"
                break;
              }
              case 9: {
                t.Categoria="Cuota"
                break;
              }      

            }
            //console.log(e);
            //console.log(t);
            lista.push(t);
          });

          return lista;
        }
      )
    )

    }

  }


