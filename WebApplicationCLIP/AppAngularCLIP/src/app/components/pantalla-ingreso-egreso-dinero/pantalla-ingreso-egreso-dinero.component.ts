import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormsModule } from '@angular/forms'
import { Usuario } from '../../modelos/usuario';
import {CuentaService} from '../../services/cuenta.service'

@Component({
  selector: 'app-pantalla-ingreso-egreso-dinero',
  templateUrl: './pantalla-ingreso-egreso-dinero.component.html',
  styleUrls: ['./pantalla-ingreso-egreso-dinero.component.css']
})
export class PantallaIngresoEgresoDineroComponent implements OnInit {

  constructor(private fb: FormBuilder, private cuentaService: CuentaService) { }

  cuentaOrigen : Usuario;
  tiposOperaciones : Array<string> = ['Deposito','Extraccion'];
  isSubmitted = false;
  labelBotonCuenta = 'Ver datos de cuenta';
  verDatosCuenta = false;
 // nombreCuenta = '';
  //apellidoCuenta ='';
  cvuCuenta = '';
  saldoCuenta : number = 0;
  usuarioCuenta = '';

  formRetiroDinero : FormGroup;
  formDinero : FormGroup;
  ngOnInit(): void {
    this.formDinero = this.fb.group({
      inputCVU: ['', [Validators.required],[Validators.maxLength(22)],[Validators.minLength(22)]],
      selectorTipoOperacion: ['', [Validators.required]],
      Monto: ['', [Validators.required, Validators.pattern("^[0-9]{1,8}$")]]
    })
  }

  get selectorTipoOperacion() {
    return this.formDinero.get('selectorTipoOperacion');
  }

  get inputCVU() {
    return this.formDinero.get('inputCVU');
  }



  public changeCuenta(e) {

    this.selectorTipoOperacion.setValue(e.target.value, {
      onlySelf: true
    })
  }

  onSubmit() {

      console.log(JSON.stringify(this.selectorTipoOperacion.value))


  }

  public LimpiarForm(){
    this.formDinero.reset();
  }

  public verCuenta(){
    this.cuentaService.obtenerCuenta(this.inputCVU.value).subscribe(
      cuenta => {
        this.cvuCuenta = cuenta.Cvu;
        this.saldoCuenta = cuenta.Saldo;
        this.usuarioCuenta = cuenta.NombreUsuario;
      }

    )
    this.verDatosCuenta = !this.verDatosCuenta;
    if( this.verDatosCuenta == true){
      this.labelBotonCuenta = 'Esconder datos de cuenta';
    }
    else{
      this.labelBotonCuenta = 'Ver datos de cuenta';
    }

  }

}
