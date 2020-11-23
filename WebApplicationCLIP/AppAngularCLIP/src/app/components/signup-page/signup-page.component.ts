import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormsModule } from '@angular/forms'
import { ActivatedRoute, Router } from '@angular/router';
import { stringify } from 'querystring';
import { Usuario } from 'src/app/modelos/usuario';
import { LoginService } from 'src/app/services/login.service';
import { SignupService } from 'src/app/services/signup.service';

@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.css']
})
export class SignupPageComponent implements OnInit {

  clavesNoCoinciden: boolean = false;
  fgroup: FormGroup; //Agrupa los datos de carga del formulario
  constructor(private fb: FormBuilder, private route: ActivatedRoute, private router: Router, private loginService: LoginService, private signupService: SignupService) { }

  ngOnInit(): void {
    //Se le indica al formGroup que vamos a crear con el FormBuilder un grupo de elementos
    // de carga constituido por un objeto json que va a contener los campos.
    this.fgroup = this.fb.group({
      NombreUsuario: ['aaaaaaaa', [Validators.required, Validators.maxLength(30), Validators.minLength(8), Validators.pattern("^[a-zA-Z0-9_-]+$")]],
      Nombre: ['asd', [Validators.required, Validators.maxLength(55), Validators.pattern("^[a-zA-Z' ]+$")]],
      Apellido: ['asd', [Validators.required, Validators.maxLength(55), Validators.pattern("^[a-zA-Z' ]+$")]],
      Email: ['ads@asd', [Validators.required, Validators.maxLength(55), Validators.email]],
      Dni: ['12345678', [Validators.required, Validators.minLength(8), Validators.pattern("^[0-9]{1,8}$")]],
      Telefono: ['126552', [Validators.pattern("^[0-9]{1,20}$")]],
      Contrasena: ['', [Validators.required, Validators.maxLength(55)]],
      ContrasenaRep: ['', [Validators.required, Validators.maxLength(55)]],
      image: ['',]

    })
  }

  grabar() {
    if (this.fgroup.valid) {

      if (this.fgroup.value.Contrasena != this.fgroup.value.ContrasenaRep) {
        this.clavesNoCoinciden = true;
        console.log("Las contraseñas no coinciden")
        return;
      } else {
        this.clavesNoCoinciden = false;
      }

      console.log("Registrando Usuario");

      var usuario = new Usuario();

      usuario.apellido = this.fgroup.value.Apellido;
      usuario.nombre = this.fgroup.value.Nombre;
      usuario.nombreDeUsuario = this.fgroup.value.NombreUsuario;
      usuario.dni = this.fgroup.value.Dni;
      usuario.email = this.fgroup.value.Email;
      usuario.telefono = this.fgroup.value.Telefono;
      usuario.sitCrediticia = "normal";
      usuario.contraseña = this.fgroup.value.Contrasena;

      console.log(usuario);


      this.signupService.registerUser(usuario).subscribe(
        () => {
           console.log("Registro Exitoso"); 
          },
        err => {
          console.log("error en el registro");
          console.log(err);
        }
      );
  

      var returnUrl = this.route.snapshot.queryParams.returnUrl || '/registroExitoso';
      if (this.loginService.usuarioLogueado) {
        this.router.navigate([returnUrl]);


      }
    }
    else {
      console.log("Hay datos invalidos")
    }

  }

  LimpiarForm() {
    this.fgroup.reset();
  }
}
