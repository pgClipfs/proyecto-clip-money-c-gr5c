import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-pagina-principal',
  templateUrl: './pagina-principal.component.html',
  styleUrls: ['./pagina-principal.component.css']
})
export class PaginaPrincipalComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, private loginService: LoginService) { }

  private returnUrl: string; 

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/login';
    if(!(this.loginService.usuarioLogueado)){
      this.router.navigate([this.returnUrl]);
      console.log("el usuario debe loguearse antes de ver la pagina principal")  
  }
  }

}
