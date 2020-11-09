import { Injectable } from '@angular/core';
//import {  HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: "root"
})

export class LoginService {

    constructor() {
    }

    prueba(user: string, pasw: string) {

        if (user == "pepe" && pasw == "123") {
            return true;
        }
        return false
    }

}