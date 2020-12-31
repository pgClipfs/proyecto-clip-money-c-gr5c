import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormsModule } from '@angular/forms'
import { Usuario } from '../../modelos/usuario';

@Component({
  selector: 'app-pantalla-ingreso-egreso-dinero',
  templateUrl: './pantalla-ingreso-egreso-dinero.component.html',
  styleUrls: ['./pantalla-ingreso-egreso-dinero.component.css']
})
export class PantallaIngresoEgresoDineroComponent implements OnInit {

  constructor(private fb: FormBuilder) { }

  cuentaOrigen : Usuario;
  origenDepositos : Array<string> = ['$ - Cuello Juan','U$D - Ramirez Juan'];
  isSubmitted = false;

  formRetiroDinero : FormGroup;
  formDinero : FormGroup;
  ngOnInit(): void {
    this.formDinero = this.fb.group({
      cvuDestino: ['', [Validators.required]],
      CuentaOrigen: ['', [Validators.required]],
      origenDeposito: ['', [Validators.required]],
      Monto: ['', [Validators.required, Validators.pattern("^[0-9]{1,8}$")]]
    })
  }

  get origenDeposito() {
    return this.formDinero.get('origenDeposito');
  }

  public changeCuenta(e) {

    this.origenDeposito.setValue(e.target.value, {
      onlySelf: true
    })
  }

  onSubmit() {

      console.log(JSON.stringify(this.origenDeposito.value))


  }

  public LimpiarForm(){
    this.formDinero.reset();
  }

}
