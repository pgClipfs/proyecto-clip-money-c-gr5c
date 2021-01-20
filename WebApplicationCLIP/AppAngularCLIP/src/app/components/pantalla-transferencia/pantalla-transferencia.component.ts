import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TransferenciasService } from '../../services/transferencias.service';
import { CategoriaTransferencia, Operacion, Cuenta, EstadoBusqueda } from '../../clases'
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { CuentaService } from 'src/app/services/cuenta.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-pantalla-transferencia',
  templateUrl: './pantalla-transferencia.component.html',
  styleUrls: ['./pantalla-transferencia.component.css']
})



export class PantallaTransferenciaComponent implements OnInit {

  estadoActual: EstadoBusqueda = EstadoBusqueda.Nada
  estadoBusqueda=EstadoBusqueda

  constructor(private formConstructor: FormBuilder, private modalService: NgbModal, private cuentaService: CuentaService, private transferenciaService: TransferenciasService, private ToastService: ToastrService) {

  }

  textobotonTransferencia: string = 'Ver ultimas transferencias';
  utimasTransferencia: boolean = false;
  transferenciaResultado: Observable<any>;

  CvuDestino: string = '';
  CvuOrigen: string = '';
  Monto: number = 0;
  Referencia: string = '';
  Categoria: string = '';

  saldoSuficiente:boolean

  saldoTransferencia: number = 0;
  transferencias: Array<Operacion> = [];
  montoMayorASaldo: boolean = false;

  cuentaOrigen: Cuenta;
  categorias = CategoriaTransferencia;
  sumbitted = false;

  formGroupTransferencia: FormGroup;

  verificarSaldoDisponible(){
    this.saldoSuficiente = (this.campoMonto.value <= this.cuentaOrigen.Saldo && this.campoMonto.value > 0)
  }

  ngOnInit(): void {

    this.formGroupTransferencia = this.formConstructor.group({

      CvuDestino: ['', [Validators.required,  Validators.pattern("^[0-9]{12}$")]],
      Monto: ['', [Validators.required, Validators.pattern("^[0-9]{1,20}$")]],
      Referencia: ['', [Validators.required, Validators.maxLength(22)]],
      Categoria: [1, [Validators.required]]
    })

    this.cuentaOrigen = new Cuenta()

    this.cuentaOrigen.Cvu = ""
    this.cuentaOrigen.Saldo = 0
    this.cuentaOrigen.NombreUsuario = ""

    this.cuentaService.obtenerCuentasUsuario().subscribe(
      cuenta => {
        this.cuentaOrigen = cuenta[0];
        this.CvuOrigen = this.cuentaOrigen.Cvu
      }, err => {
      }, () => {

      }
    )
  }



  titularCuentaDestino: string;
  emailCuentaDestino: string;
  cvuCuentaDestino: string;


  public buscarCuenta() {

    var cvu : string;
    cvu = this.campoCvuDestino.value;

    this.estadoActual=EstadoBusqueda.Nada;

    if(cvu.length != 12){
      return;
    }

    this.estadoActual=EstadoBusqueda.Buscando;

    this.cuentaService.obtenerCuentaOtroUsuario(this.campoCvuDestino.value).subscribe(
      cuenta => {
        this.estadoActual=EstadoBusqueda.ResultadoExitoso
        this.titularCuentaDestino = cuenta.datosUsuario.Nombre + " " + cuenta.datosUsuario.Apellido
        this.emailCuentaDestino = cuenta.datosUsuario.Email
        this.cvuCuentaDestino= cuenta.Cvu
      }, err => {
        this.estadoActual=EstadoBusqueda.Error

      }, () => {
      }
    )
  }

  public realizarTransferencia() {

    this.transferenciaService.realizarTransferencia(this.CvuDestino, this.Monto, this.Referencia, this.CvuOrigen, this.Categoria)
      .subscribe(
        data => {
          this.transferenciaResultado = data;
          this.showToastrSucces('Operacion realizada con exito', 'Nueva Transferencia');
          this.sumbitted = false;
          this.limpiarForm();
          this.estadoActual = this.estadoBusqueda.Nada;

        },
        err => {
          console.log(err);
          this.showToastrError(err, 'Operacion Fallida')


        }
      )

    this.modalService.dismissAll()
  }

  public getTransferencias() {
    this.transferenciaService.obtenerTransferencias(this.CvuOrigen)
      .subscribe(
        data => {
          this.transferencias = data;
        },
        err => {
          console.log(err);
          this.showToastrError(err, 'Operacion Fallida')


        }
      )
  }

  public showToastrSucces(mensajeAlert: string, tituloAlert: string) {
    this.ToastService.success(mensajeAlert, tituloAlert)
  }

  public showToastrError(mensajeAlert: string, tituloAlert: string) {
    this.ToastService.error(mensajeAlert, tituloAlert)
  }

  public AbrirCerrarNuevaTransferencia() {
    this.getTransferencias();
    this.utimasTransferencia = !this.utimasTransferencia;
    if (this.utimasTransferencia == true) {
      this.textobotonTransferencia = 'Cerrar';
    }
    else {
      this.textobotonTransferencia = 'Ver ultimas transferencias';
    }
  }

  openVerticallyCentered(content) {
    //cambiamos la variable de sumbitted a true
    this.sumbitted = true;
    //Verifica los validadores
    if (this.formGroupTransferencia.invalid || this.estadoActual == this.estadoBusqueda.Error || !this.saldoSuficiente) {
      return;
    }

    this.modalService.open(content, { centered: true });
    this.CvuDestino = this.campoCvuDestino.value;
    this.Monto = this.campoMonto.value;
    this.Referencia = this.campoReferencia.value;
    this.Categoria = this.campoCategoria.value;
  }

  get campoCvuDestino() {
    return this.formGroupTransferencia.get('CvuDestino');
  }

  get campoMonto() {
    return this.formGroupTransferencia.get('Monto');
  }

  get campoCategoria() {
    return this.formGroupTransferencia.get('Categoria');
  }

  get campoReferencia() {
    return this.formGroupTransferencia.get('Referencia');
  }

  public limpiarForm() {
    this.formGroupTransferencia.reset();
  }
}
