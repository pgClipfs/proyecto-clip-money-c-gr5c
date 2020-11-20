import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  usuarioLogueado:boolean;

  constructor(private loginService: LoginService) { }

  cerrar_sesion(){
    this.loginService.logout();
    location.reload();
  }
  
  ngOnInit(): void {
    this.usuarioLogueado=this.loginService.userLoggedIn();
  }

}
