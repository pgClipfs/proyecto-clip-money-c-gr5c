import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { Usuario } from '../../modelos/usuario';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, private loginService: LoginService) { }
  
  returnUrl: string;

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/principal';
    if(this.loginService.sesionEstaAbierta){
        this.router.navigate([this.returnUrl]);
        console.log("el usuario ya esta logueado");
  }}

}
