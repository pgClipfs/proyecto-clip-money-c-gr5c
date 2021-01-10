import { Component } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { Usuario } from '../../modelos/usuario';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'login-box',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginBox {

    msg_error:string;

    value_user: string;
    value_pasw: string;
    error: boolean = false;

    user: Usuario;
    returnUrl: string;

    limpiar_mensaje_error() {
        this.error = false;
    }

    login_click() {

        this.loginService.login(this.value_user, this.value_pasw)
            .subscribe(
                user => {
                    this.router.navigate([this.returnUrl]);
                    console.log("credenciales validas")
                },
                err => {
                    this.error = true;

                    this.msg_error=err.error;

                    this.value_user = "";
                    this.value_pasw = "";
                }
            );
    }

    constructor(private route: ActivatedRoute, private router: Router, private loginService: LoginService) { }


    ngOnInit(): void {
        this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/home';
        if(this.loginService.sesionEstaAbierta()){
            this.router.navigate([this.returnUrl]);
            console.log("el usuario ya esta logueado")
            //intento de q no se pueda ver el login, si el usuario ya esta logueado

            //los botones de iniciar sesion y todo eso tampoco se deberian mostrar, solo el de "cerrar Sesion"

        }
    }

}

