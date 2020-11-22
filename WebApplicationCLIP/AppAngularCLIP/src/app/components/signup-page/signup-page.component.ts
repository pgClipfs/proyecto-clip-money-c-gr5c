import { Component, OnInit } from '@angular/core';
import { FormBuilder,Validators, FormGroup, FormsModule} from '@angular/forms'
import { stringify } from 'querystring';

@Component({
  selector: 'app-signup-page',
  templateUrl: './signup-page.component.html',
  styleUrls: ['./signup-page.component.css']
})
export class SignupPageComponent implements OnInit {

  fgroup: FormGroup; //Agrupa los datos de carga del formulario
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    //Se le indica al formGroup que vamos a crear con el FormBuilder un grupo de elementos
    // de carga constituido por un objeto json que va a contener los campos.
    this.fgroup = this.fb.group({
      NombreUsuario: '',
      Nombre: '',
      Apellido: '',
      Email: '',
      Dni: 0,
      Telefono: 0,
      Contrasena: '',
      ContrasenaRep: '',
      image: ''
      

    })
  }

  grabar(){
    console.log(this.fgroup.value)
  }
}
