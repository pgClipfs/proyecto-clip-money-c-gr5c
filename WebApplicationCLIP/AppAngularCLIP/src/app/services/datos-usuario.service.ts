import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { retry ,catchError,map} from 'rxjs/operators';
import { Sesion } from '../clases';
import { Usuario } from '../modelos/usuario';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class DatosUsuarioService {
  private urlApi = "http://localhost:59642/api/"; //linea para hacer pruebas
 
  constructor(private http: HttpClient, private loginService: LoginService) { }

  public obtenerDatosUsuario(): Observable<Usuario> {

  var sesion= this.loginService.obtenerSesionActual;
  
    return this.http.post<any>(this.urlApi + 'get/usuario',
      sesion)
      .pipe(
        retry(2), //esto es para decirle cuantas veces lo tiene que intentar antes de tirar error :o
        catchError(err => {
         throw err.error;
        }), 
        map(user => { 
       //   console.log("Usuario Encontrado:");
         // console.log(user);
          return user;
        }
        )
      );
  }
}
