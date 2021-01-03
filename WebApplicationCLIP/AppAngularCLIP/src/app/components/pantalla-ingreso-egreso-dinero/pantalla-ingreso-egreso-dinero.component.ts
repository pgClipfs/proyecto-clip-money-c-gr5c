import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormsModule } from '@angular/forms'
import { Cuenta } from 'src/app/clases';
import { OperacionService } from 'src/app/services/operacion.service';
import { Usuario } from '../../modelos/usuario';
import { CuentaService } from '../../services/cuenta.service'

@Component({
  selector: 'app-pantalla-ingreso-egreso-dinero',
  templateUrl: './pantalla-ingreso-egreso-dinero.component.html',
  styleUrls: ['./pantalla-ingreso-egreso-dinero.component.css']
})
export class PantallaIngresoEgresoDineroComponent implements OnInit {

  constructor(private operacionService: OperacionService, private fb: FormBuilder, private cuentaService: CuentaService) { }

  //esta cuenta, se carga automaticamente cuando se abre la ventana
  //@Input()
  cuentaOrigen: Cuenta
  cvuIngresado: string = "1234";
 
  public buscarCuenta() {

    this.cuentaOrigen.Cvu = "a"
    this.cuentaOrigen.Saldo = 0
    this.cuentaOrigen.NombreUsuario = ""

    this.cuentaService.obtenerCuenta(this.cvuIngresado).subscribe(
      cuenta => {
        this.cuentaOrigen = cuenta;
      }, err => {
        this.cuentaOrigen.NombreUsuario = "no se encontro la cuenta :c"
      }, () => {
      }
    )
  }

  public realizarOperacion() {
    /*  var cvu = "00002222"
      var monto = 1000
      this.operacionService.realizarDeposito(cvu, monto);*/
  }

  ngOnInit(): void {

    this.cuentaOrigen = new Cuenta()

    this.cuentaOrigen.Cvu = ""
    this.cuentaOrigen.Saldo = 0
    this.cuentaOrigen.NombreUsuario = ""

    this.cuentaService.obtenerCuentasUsuario().subscribe(
      cuenta => {
        this.cuentaOrigen = cuenta[0];
      }, err => {
      }, () => {

      }
    )

    //#region 
    this.formDinero = this.fb.group({
      inputCVU: ['', [Validators.required], [Validators.maxLength(22)], [Validators.minLength(22)]],
      selectorTipoOperacion: ['', [Validators.required]],
      Monto: ['', [Validators.required, Validators.pattern("^[0-9]{1,8}$")]]
    })
  }

  tiposOperaciones: Array<string> = ['Deposito', 'Extraccion'];
  isSubmitted = false;
  labelBotonCuenta = 'Ver datos de cuenta';
  verDatosCuenta = true;

  formRetiroDinero: FormGroup;
  formDinero: FormGroup;

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

  public LimpiarForm() {
    this.formDinero.reset();
  }

  public verCuenta() {


    this.verDatosCuenta = !this.verDatosCuenta;
    if (this.verDatosCuenta == true) {
      this.labelBotonCuenta = 'Esconder datos de cuenta';
    }
    else {
      this.labelBotonCuenta = 'Ver datos de cuenta';
    }

  }
  //#endregion
}
