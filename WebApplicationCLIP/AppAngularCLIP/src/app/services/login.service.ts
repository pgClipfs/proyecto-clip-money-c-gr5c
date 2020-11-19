import { Injectable } from '@angular/core';
import {  HttpClient } from "@angular/common/http";
import { HttpClientModule } from '@angular/common/http';
import {Usuario } from '../modelos/usuario';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: "root"
})

export class LoginService {

private regUrl = "url de registro";
private logUrl = "url de logueo";
private pruebaURL: string= "http://localhost:59642/api/Prueba02/7";
private urlApi = "api";
private usuarioActualSubject: BehaviorSubject<Usuario>;
private usuarioActual: Observable<Usuario>;

constructor(private http: HttpClient) {
    this.usuarioActualSubject = new BehaviorSubject<Usuario>(JSON.parse(localStorage.getItem
        ('usuarioActual')));
    this.usuarioActual = this.usuarioActualSubject.asObservable();
    //el local storage puede tener el usuario guardado, pero tambien puede que no
    //entonces en usuarioActual solo se carga el usuario si este ya estaba en el localstorage
}

public get usuarioLogueado(): Usuario {
    return this.usuarioActualSubject.value;
}

public login(nombreDeUsuario: string, contraseña: string): Observable<any> {
    //en este punto se deberia encriptar la contraseña

    //se hace un post al cliente http, en esa url, y se le pasa un "objeto usuario" como parametro
    return this.http.post<any>(this.urlApi + 'api/login/authenticate',
        { nombreDeUsuario, contraseña })
        .pipe(map(
            user => {
                localStorage.setItem('usuarioActual', JSON.stringify(user));
                this.usuarioActualSubject.next(user);
                return user;
            }));


    //con "pipe" se toma lo que viene del servidor

}

public logout(): void {
    localStorage.removeItem('usuarioActual');
    this.usuarioActualSubject.next(null);

}



probar(): Observable<Usuario> {
    console.log(this.http.get(this.pruebaURL));
    return this.http.get<Usuario>(this.pruebaURL);
}
}