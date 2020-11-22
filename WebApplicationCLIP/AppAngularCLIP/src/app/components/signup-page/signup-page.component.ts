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
      Nombre: ['',[Validators.required,Validators.maxLength(55),Validators.pattern("^[a-zA-Z' ]+$")]],
      Apellido: '',
      Email: '',
      Dni: null,
      Telefono: null,
      Contrasena: '',
      ContrasenaRep: '',
      image: ''
      

    })
  }

  grabar(){
    if(this.fgroup.valid ){
      console.log(this.fgroup.value)
    }
    else{
      console.log("Hay datos invalidos")
    }
    
  }

  

  LimpiarForm(){
    this.fgroup.reset();
  }
}
