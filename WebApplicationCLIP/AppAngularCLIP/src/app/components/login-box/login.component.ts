import { Component } from '@angular/core';
//import { AnyMxRecord } from 'dns';
import { LoginService } from 'src/app/services/login.service';


@Component({
    selector: 'login-box',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginBox {

    value_user: string;
    value_pasw: string;
    error: boolean = false;

    constructor(private loginService: LoginService) { }

    login_click() {

        if (this.loginService.prueba(this.value_user, this.value_pasw)) {
            //significa que usuario y pass coinciden

            console.log("login exitoso");
            this.error = false;

        } else {
            console.log("usuario y/o contraseña incorrectos");
            this.error = true;

        }


    }

}

