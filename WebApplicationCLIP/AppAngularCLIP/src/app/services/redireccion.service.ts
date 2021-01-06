import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RedireccionService {

  constructor(private route: ActivatedRoute, private router: Router) { }
  
  public a(direccion: string){
    var returnUrl = this.route.snapshot.queryParams.returnUrl || '/'+direccion;
    this.router.navigate([returnUrl]);   
  }

  public login(){
    var returnUrl = this.route.snapshot.queryParams.returnUrl || '/login';
    this.router.navigate([returnUrl]);   
  }
  
  public landingPage(){
    var returnUrl = this.route.snapshot.queryParams.returnUrl || '/';
    this.router.navigate([returnUrl]);       
  }
  
  public principal(){
    var returnUrl = this.route.snapshot.queryParams.returnUrl || '/principal';
    this.router.navigate([returnUrl]);   
  }
  public exito(){
    var returnUrl = this.route.snapshot.queryParams.returnUrl || '/exito';
    this.router.navigate([returnUrl]);   
  }
  public fallo(){
    var returnUrl = this.route.snapshot.queryParams.returnUrl || '/fallo';
    this.router.navigate([returnUrl]);   
  }
}
