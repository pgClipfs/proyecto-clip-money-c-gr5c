import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormsModule } from '@angular/forms'
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Cuenta } from 'src/app/clases';
import { OperacionService } from 'src/app/services/operacion.service';
import { RedireccionService } from 'src/app/services/redireccion.service';
import { Usuario } from '../../modelos/usuario';
import { CuentaService } from '../../services/cuenta.service'

@Component({
  selector: 'app-pantalla-ingreso-egreso-dinero',
  templateUrl: './pantalla-ingreso-egreso-dinero.component.html',
  styleUrls: ['./pantalla-ingreso-egreso-dinero.component.css']
})
export class PantallaIngresoEgresoDineroComponent implements OnInit {

  constructor(private ToastService: ToastrService, private redireccionar: RedireccionService, private operacionService: OperacionService, private fb: FormBuilder, private cuentaService: CuentaService) { }

  //esta cuenta, se carga automaticamente cuando se abre la ventana
  //@Input()
  cuentaOrigen: Cuenta
  cvuIngresado: string;



  public buscarCuenta() {

    this.cuentaOrigen.Cvu = "cargando datos"
    this.cuentaOrigen.Saldo = 0
    this.cuentaOrigen.NombreUsuario = ""

    this.cuentaService.obtenerCuenta(this.inputCVU.value).subscribe(
      cuenta => {
        this.cuentaOrigen = cuenta;
      }, err => {
        this.cuentaOrigen.NombreUsuario = err.error
      }, () => {
      }
    )
  }



  public realizarOperacion() {

    var boton = <HTMLInputElement>document.getElementById("botonConfirmar")
    boton.disabled = true;

    if (this.inputMonto.value <= 0 || this.inputMonto == null) {
      this.showToastrError('error: ingrese un monto valido', 'Operacion fallida')
      boton.disabled = false;
      return;
    }

    if (this.selectorTipoOperacion.value == "Deposito") {
      this.operacionService.realizarDeposito(this.cuentaOrigen.Cvu, this.inputMonto.value).subscribe(
        x => {
          this.showToastrSucces('Deposito realizado con exito', 'Deposito')
          //boton.disabled = false;
        },
        err => {
          console.log(err);
          alert(err.error);
          boton.disabled = false;
          //this.redireccionar.fallo();
          //this.modalService.dismissAll()
        }, async () => {
          await this.delay(600);
          window.location.reload();
        }

      );
      return;
    }

    if (this.selectorTipoOperacion.value == "Extraccion") {
      this.operacionService.realizarExtraccion(this.cuentaOrigen.Cvu, this.inputMonto.value).subscribe(
        x => {
          console.log("Extraccion realizado exitosamente");
          this.showToastrSucces('Extraccion realizado exitosamente', 'Extraccion')
          //boton.disabled = false;
        },
        err => {

          this.showToastrError(err.error, 'Operacion fallida')
          boton.disabled = false;

          //this.modalService.dismissAll()
        }, async () => {
          await this.delay(600);
          window.location.reload();

        }
      );
      return;
    }
    this.showToastrError('error: seleccione un tipo de operacion', 'Operacion fallida')
    boton.disabled = false;
  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }

  ngOnInit(): void {

    this.cuentaOrigen = new Cuenta()

    this.cuentaOrigen.Cvu = ""
    this.cuentaOrigen.Saldo = 0
    this.cuentaOrigen.NombreUsuario = ""

    this.cuentaService.obtenerCuentasUsuario().subscribe(
      cuenta => {
        this.cuentaOrigen = cuenta[0];
        this.cvuIngresado = this.cuentaOrigen.Cvu
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

  get inputMonto() {
    return this.formDinero.get('Monto');
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

  //Alerts
  public showToastrSucces(mensajeAlert: string, tituloAlert: string) {
    this.ToastService.success(mensajeAlert, tituloAlert)
  }

  public showToastrError(mensajeAlert: string, tituloAlert: string) {
    this.ToastService.error(mensajeAlert, tituloAlert)
  }
}
