import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { retry ,catchError,map} from 'rxjs/operators';
import { Sesion } from '../modelos/sesion';
import { Usuario } from '../modelos/usuario';
import { LoginService } from './login.service';

@Injectable({
  providedIn: "root"
})
export class OperacionesService {

    private urlApi = "http://localhost:59642/api/"; //linea para hacer pruebas
    constructor(private http: HttpClient, private loginService: LoginService) {}

    getOperaciones(): Observable<any>{
        return this.http.get('http://localhost:59642/api/');
      }
    }