import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from 'src/app/modelos/usuario';
import { DatosUsuarioService } from 'src/app/services/datos-usuario.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-pagina-principal',
  templateUrl: './pagina-principal.component.html',
  styleUrls: ['./pagina-principal.component.css']
})
export class PaginaPrincipalComponent implements OnInit {

  usuario: Usuario;
  nombreUsuario: string = "Usuario generico";

  cerrar_sesion(text?: string) {
    this.loginService.logout();
    //location.reload();

    var returnUrl = this.route.snapshot.queryParams.returnUrl || '/';

    if (text == "") text = "Sesion cerrada";

    console.log(text);
    this.router.navigate([returnUrl]);
  }


  constructor(private route: ActivatedRoute, private router: Router, private loginService: LoginService, private datosUsuarioService: DatosUsuarioService) { }

  private returnUrl: string;

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/login';
    if (!(this.loginService.sesionEstaAbierta)) {
      this.router.navigate([this.returnUrl]);
      console.log("el usuario debe loguearse antes de ver la pagina principal")
    }
    this.datosUsuarioService.obtenerDatosUsuario().subscribe(
      user => {
        //parece que todo bien
        //   console.log(user);
        this.usuario = user;
        this.nombreUsuario = this.usuario.Nombre + " " + this.usuario.Apellido;
      },
      err => {
        console.log(err);

        this.loginService.logout();
            
        var returnUrl = this.route.snapshot.queryParams.returnUrl || '/login';          
        this.router.navigate([returnUrl]);
      }
    );

  }

}
