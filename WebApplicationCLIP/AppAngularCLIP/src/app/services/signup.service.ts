import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../modelos/usuario';
import { BehaviorSubject, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class SignupService {
  
  private urlApi = "http://localhost:59642/api/"; //linea para hacer pruebas

  public validate(): boolean {
    /*esta funcion lo que hace es consultar la BD para comprobar que no haya
    un usuario que ya tenga ese dni, nombre usuario, email, etc.
    pero por ahora solo devuelve true y deja pasar lo que sea
    */
    return true;
  }
 
  public registerUser(usuario: Usuario): Observable<any> {
    //return this.http.post<any>(this.urlApi + 'registration/registerUser',{dni,nombreDeUsuario});

    return this.http.post<any>(this.urlApi + 'login/registerUser',
      usuario)
      .pipe(catchError(err => {
        if (err.error == 2) {
          throw "error en el insert"
        }
        if (err.error == 3) {
          throw "dni repetido"
        }
        if (err.error == 4) {
          throw "nombre de usuario repetido"
        }
        if (err.error == 5) {
          throw "email repetido"
        }
        throw "error misterioso (error tipo "+err.error+")"
      }),
        map(
          () => {
            return "usuario registrado correctamente";
          }));

  }

  constructor(private http: HttpClient) { }

}
