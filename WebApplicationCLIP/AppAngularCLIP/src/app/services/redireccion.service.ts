import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RedireccionService {

  constructor(private route: ActivatedRoute, private router: Router) { }
  
  public redireccionar(direccion: string){

  }

  public login(){
    var returnUrl = this.route.snapshot.queryParams.returnUrl || '/login';
    this.router.navigate([returnUrl]);   
  }
  
  public landingPage(){
    var returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
    this.router.navigate([returnUrl]);       
  }
  
  public home(){
    var returnUrl = this.route.snapshot.queryParams.returnUrl || '/principal';
    this.router.navigate([returnUrl]);       

  }
}
