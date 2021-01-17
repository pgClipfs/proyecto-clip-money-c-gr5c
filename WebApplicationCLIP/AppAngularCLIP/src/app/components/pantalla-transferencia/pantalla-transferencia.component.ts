import { Component, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';
import { TransferenciasService} from '../../services/transferencias.service';
import {CategoriaTransferencia, Operacion, Cuenta} from '../../clases'
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


  constructor(private modalService: NgbModal,private cuentaService: CuentaService  , private transferenciaService : TransferenciasService, private ToastService : ToastrService) { }

  textobotonTransferencia : string = 'Ver ultimas transferencias';
  utimasTransferencia : boolean = false;
  transferenciaPrueba : Observable<any>;
  CvuDestino : string = '000040444444';
  CvuOrigen : string = '000040666666';
  Monto : number = 60;
  Referencia : string = 'Test';
  Categoria : string = CategoriaTransferencia.Expensas.toString();
  saldoTransferencia : number = 2500;
  transferencias : Array<Operacion> = [];
  cuentaOrigen : Cuenta;
  categorias = CategoriaTransferencia;


  ngOnInit(): void {

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

    this.getTransferencias();
  }

  public buscarCuenta() {

    this.cuentaOrigen.Cvu = "cargando datos"
    this.cuentaOrigen.Saldo = 0
    this.cuentaOrigen.NombreUsuario = ""

    this.cuentaService.obtenerCuenta(this.CvuOrigen).subscribe(
      cuenta => {
        this.cuentaOrigen = cuenta;
        this.saldoTransferencia = cuenta.Saldo;
      }, err => {
        this.cuentaOrigen.NombreUsuario = err.error
      }, () => {
      }
    )
  }

  public realizarTransferencia(){
    this.transferenciaService.realizarTransferencia(this.CvuDestino,this.Monto,this.Referencia,this.CvuOrigen,this.Categoria)
    .subscribe(
      data => {
        this.transferenciaPrueba = data;
        this.showToastrSucces('Operacion realizada con exito','Nueva Transferencia');
      },
      err => {
        console.log(err);
        this.showToastrError(err,'Operacion Fallida')


      }
    )

    this.modalService.dismissAll()
  }

  public getTransferencias(){
    this.transferenciaService.obtenerTransferencias(this.CvuOrigen)
    .subscribe(
      data => {
        this.transferencias = data;
      },
      err => {
        console.log(err);
        this.showToastrError(err,'Operacion Fallida')


      }
    )
  }

  public showToastrSucces(mensajeAlert : string, tituloAlert: string){
    this.ToastService.success(mensajeAlert, tituloAlert)
  }

  public showToastrError(mensajeAlert : string, tituloAlert: string){
    this.ToastService.error(mensajeAlert, tituloAlert)
  }

  public AbrirCerrarNuevaTransferencia(){
    this.utimasTransferencia = !this.utimasTransferencia;
    if (this.utimasTransferencia == true)
    {
      this.textobotonTransferencia = 'Cerrar';
    }
    else{
      this.textobotonTransferencia = 'Ver ultimas transferencias';
    }
  }

  openVerticallyCentered(content) {
    this.modalService.open(content, { centered: true });
  }

}
