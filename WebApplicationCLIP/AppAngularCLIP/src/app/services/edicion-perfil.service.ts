import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Usuario } from '../modelos/usuario';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { LoginService } from 'src/app/services/login.service';

@Injectable({
  providedIn: 'root',
})
export class EdicionPerfilService {
  private urlApi = 'http://localhost:59642/api/';
  public updateUser(usuario: Usuario): Observable<any> {
    let SesionDeUsuario = this.loginService.obtenerSesionActual;
    console.log(usuario);
    console.log(SesionDeUsuario);
    return this.http
      .post<any>(this.urlApi + 'post/modificardatosusuario', {
        usuario,
        SesionDeUsuario,
      })
      .pipe(
        catchError((err) => {
          throw err.error;
        }),
        map(() => {
          return 'usuario actualizado correctamente';
        })
      );
  }

  constructor(private http: HttpClient, private loginService: LoginService) {}
}
