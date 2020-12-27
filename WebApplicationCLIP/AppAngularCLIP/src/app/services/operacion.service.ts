import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpClientModule } from '@angular/common/http';
import { Usuario } from '../modelos/usuario';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class OperacionService {

  private urlApi = "http://localhost:59642/api/"; //linea para hacer pruebas


  constructor(private http: HttpClient, private loginService: LoginService) { }


  public getOperacionesCvu(cvu: string): Observable<any> {

    // this.loginService.usuarioLogueado

    return this.http.post<any>(this.urlApi + 'get/operaciones',
      cvu)
      .pipe(
        retry(2), //esto es para decirle cuantas veces lo tiene que intentar antes de tirar error :o
        catchError(err => {
          return err;
        }),
        map(ops => {
          //operaciones: Operacion[]          
          return ops;
        }
        )
      );
  }
}
