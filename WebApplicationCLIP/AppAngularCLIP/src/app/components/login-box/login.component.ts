import { Component } from '@angular/core';
//import { AnyMxRecord } from 'dns';
import { LoginService } from 'src/app/services/login.service';
//import { HttpClient } from "@angular/common/http";


//import { Usuario } from '../../modelos/usuario';
import {Usuario } from '../../modelos/usuario';
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


    constructor(private route: ActivatedRoute, private router: Router, private loginService: LoginService) { }
    ngOnInit(): void {
        this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
        //(no se muy bien que hace esta linea...)
    }
    
    login_click() {       
     

        this.loginService.login(this.value_user, this.value_pasw)
        .subscribe(
            () => {
                this.router.navigate([this.returnUrl]);
            },
            error => {
                this.error = error;
            }
        );

    /*
            this.loginService.probar().subscribe((data: any) => {
                this.user = data;
                this.value_user = this.user.Nombre;            
            });*/
    }

}

