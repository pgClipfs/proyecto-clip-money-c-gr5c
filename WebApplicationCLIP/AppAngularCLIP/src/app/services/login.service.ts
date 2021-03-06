import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpClientModule } from '@angular/common/http';
import { Sesion } from '../clases';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, retry, catchError } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
import { RedireccionService } from './redireccion.service';

@Injectable({
  providedIn: "root"
})

export class LoginService {
  //private urlApi = "api/"; //linea correcta 
  private urlApi = "http://localhost:59642/api/"; //linea para hacer pruebas
  private sesionActualSubject: BehaviorSubject<Sesion>;
  private sesionActual: Observable<Sesion>;

  constructor(private http: HttpClient, private redireccionar: RedireccionService) {
    this.sesionActualSubject = new BehaviorSubject<Sesion>(JSON.parse(localStorage.getItem
      ('sesionActual')));
    this.sesionActual = this.sesionActualSubject.asObservable();
  }

  public get obtenerSesionActual(): Sesion {

    if (!(this.sesionEstaAbierta)) {
      //en este if se comprueba si el usuario tiene la sesion abierta, y si no es asi, se lo manda al login 
      //this.redireccionar.login()
    }
    return this.sesionActualSubject.value;
  }

  public sesionEstaAbierta() {

    return this.sesionActualSubject.value != null;
  }

  public login(nombreDeUsuario: string, contraseña: string): Observable<any> {

    this.logout();
    //en este punto se deberia encriptar la contraseña

    return this.http.post<any>(this.urlApi + 'login/authenticate',
      { contraseña, nombreDeUsuario })
      .pipe(
        retry(5), //esto es para decirle cuantas veces lo tiene que intentar antes de tirar error :o
        catchError(err => {

          //detectar si esta caido el backend
          if (err.status == 0) {
            throw "No se pudo establecer conexion con el servidor";
          }

          throw err.error;
        }), //esto es para procesar los errores que devuelva el backend
        map(sesion => {
          localStorage.setItem('sesionActual', JSON.stringify(sesion));
          this.sesionActualSubject.next(sesion);
          this.sesionActual = this.sesionActualSubject.asObservable();
          return sesion;
        }
        )
      );
  }

  public logout(): void {
    localStorage.removeItem('sesionActual');
    this.sesionActualSubject.next(null);
    //this.redireccionar.landingPage()
  }


}