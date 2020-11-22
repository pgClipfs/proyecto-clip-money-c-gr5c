import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  usuarioLogueado:boolean;

  private returnUrl: string;

  constructor(private route: ActivatedRoute, private router: Router, private loginService: LoginService) { }

  cerrar_sesion(){
    this.loginService.logout();
    //location.reload();
    
    console.log("Sesion cerrada")
    this.router.navigate([this.returnUrl]);
  }
  
  ngOnInit(): void {
    this.usuarioLogueado=this.loginService.userLoggedIn();
      this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
  }

}
