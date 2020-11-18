import { Component } from '@angular/core';
//import { AnyMxRecord } from 'dns';
import { LoginService } from 'src/app/services/login.service';
//import { HttpClient } from "@angular/common/http";


//import { Usuario } from '../../modelos/usuario';
import {Usuario } from '../../modelos/usuario';

@Component({
    selector: 'login-box',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginBox {

    value_user: string;
    value_pasw: string;
    error: boolean = false;

    user: Usuario;

    constructor(private loginService: LoginService) { }

    ngOnInit(): void {
        //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        //Add 'implements OnInit' to the class.
        
    }
    
    login_click() {
        
        this.loginService.probar().subscribe((data: any) => {
            this.user = data;
            this.value_user = this.user.Nombre;
        });

    }

}

