import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.css']
})
export class SignupPageComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, private loginService: LoginService) { }

  ngOnInit(): void {
    var returnUrl = this.route.snapshot.queryParams.returnUrl || '/principal';
    if (this.loginService.usuarioLogueado) {
      this.router.navigate([returnUrl]);
      console.log("el usuario ya esta logueado")  
    }
  }
}
