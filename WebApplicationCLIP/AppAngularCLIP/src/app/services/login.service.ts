import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpClientModule } from '@angular/common/http';
import { Usuario } from '../modelos/usuario';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: "root"
})

export class LoginService {

      //private urlApi = "api/"; //linea correcta 
    private urlApi =  "http://localhost:59642/api/"; //linea para hacer pruebas
    private usuarioActualSubject: BehaviorSubject<Usuario>;
    private usuarioActual: Observable<Usuario>;

    constructor(private http: HttpClient) {
        this.usuarioActualSubject = new BehaviorSubject<Usuario>(JSON.parse(localStorage.getItem
            ('usuarioActual')));
        this.usuarioActual = this.usuarioActualSubject.asObservable();
    }

    public get usuarioLogueado(): Usuario {
        return this.usuarioActualSubject.value;
    }

    public userLoggedIn():  boolean{
        return this.usuarioLogueado!=null;
    }

    public login(nombreDeUsuario: string, contraseña: string): Observable<any> {

        this.logout();

        //en este punto se deberia encriptar la contraseña

        return this.http.post<any>(this.urlApi + 'login/authenticate',
            { nombreDeUsuario, contraseña })
            .pipe(map(
                user => {
                    localStorage.setItem('usuarioActual', JSON.stringify(user));
                    this.usuarioActualSubject.next(user);
                    this.usuarioActual = this.usuarioActualSubject.asObservable();      
                    return user;
                }));
    }

    public logout(): void {
        localStorage.removeItem('usuarioActual');
        this.usuarioActualSubject.next(null);
    }


}