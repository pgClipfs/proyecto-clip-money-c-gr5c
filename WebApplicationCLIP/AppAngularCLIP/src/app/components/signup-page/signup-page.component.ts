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
      NombreUsuario: ['', [Validators.required, Validators.maxLength(30), Validators.minLength(8), Validators.pattern("^[a-zA-Z0-9_-]+$")]],
      Nombre: ['', [Validators.required, Validators.maxLength(55), Validators.pattern("^[a-zA-Z' ]+$")]],
      Apellido: ['', [Validators.required, Validators.maxLength(55), Validators.pattern("^[a-zA-Z' ]+$")]],
      Email: ['', [Validators.required, Validators.maxLength(55), Validators.email]],
      Dni: ['', [Validators.required, Validators.minLength(8), Validators.pattern("^[0-9]{1,8}$")]],
      Telefono: ['', [Validators.pattern("^[0-9]{1,20}$")]],
      Contrasena: ['', [Validators.required, Validators.minLength(8),  Validators.maxLength(55)]],
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

      usuario.Apellido = this.fgroup.value.Apellido;
      usuario.Nombre = this.fgroup.value.Nombre;
      usuario.NombreDeUsuario = this.fgroup.value.NombreUsuario;
      usuario.Dni = this.fgroup.value.Dni;
      usuario.Email = this.fgroup.value.Email;
      usuario.Telefono = this.fgroup.value.Telefono;
      usuario.SitCrediticia = "normal";
      usuario.Contraseña = this.fgroup.value.Contrasena;

      console.log(usuario);


      this.signupService.registerUser(usuario).subscribe(
        () => {
           console.log("Registro Exitoso"); 
           var returnUrl = this.route.snapshot.queryParams.returnUrl || '/registroExitoso';   
           this.router.navigate([returnUrl]);
          },
        err => {
          console.log("error en el registro");
          console.log(err);
        }
      );  
    }
    else {
      console.log("Hay datos invalidos")
    }

  }

  LimpiarForm() {
    this.fgroup.reset();
  }
}
