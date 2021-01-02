import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { Usuario } from '../../modelos/usuario';
import { ActivatedRoute, Router } from '@angular/router';
import { RedireccionService } from 'src/app/services/redireccion.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private redireccionar:RedireccionService , private loginService: LoginService) { }
  
  returnUrl: string;

  ngOnInit(): void {

    if(this.loginService.sesionEstaAbierta()){
        this.redireccionar.home()
  }}

}
