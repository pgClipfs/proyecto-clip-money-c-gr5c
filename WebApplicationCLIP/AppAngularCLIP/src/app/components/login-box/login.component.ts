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
                () => {
                    this.router.navigate([this.returnUrl]);
                    console.log("credenciales validas")
                },
                error => {
                    this.error = true;
                    console.log("credenciales invalidas")

                    this.value_user = "";
                    this.value_pasw = "";
                }
            );
    }

    constructor(private route: ActivatedRoute, private router: Router, private loginService: LoginService) { }
    ngOnInit(): void {
        this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
    }

}

