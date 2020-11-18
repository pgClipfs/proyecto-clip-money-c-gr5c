import { Injectable } from '@angular/core';
import {  HttpClient } from "@angular/common/http";
import { HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';
//import { Usuario } from '../modelos/usuario';
import {Usuario } from '../modelos/usuario';

@Injectable({
    providedIn: "root"
})

export class LoginService {

private regUrl = "url de registro";
private logUrl = "url de logueo";
private pruebaURL: string= "http://localhost:59642/api/Prueba02/7";

 constructor(private http: HttpClient) { }

    probar()  {
        console.log(this.http.get(this.pruebaURL));        
        return this.http.get(this.pruebaURL);        
    }    
}