using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationCLIP.BD;
using WebApplicationCLIP.Gestores;
using System.Globalization;

namespace WebApplicationCLIP.Models
{
    public class Transferencia : Operacion
    {
        public new void BorrarDatosEscenciales()
        {
            this.CuentaDestino = null;            
            base.BorrarDatosEscenciales();
        }

        public enum CategoriaTransferencia { Varios, Alquiler, AportesDeCapital, Expensas, Factura, Haberes, Honorarios, Prestamo, Seguro, Cuota };

        public string NumeroTransferencia { get; protected set; }
        public Cuenta CuentaDestino { get; protected set; }
        public string ReferenciaDestino { get; protected set; }
        public CategoriaTransferencia Categoria { get; protected set; }

        public Transferencia()
        {

        }

        public Transferencia(Cuenta cuentaDestino, Cuenta cuentaOrigen,  float monto, CategoriaTransferencia categoria) 
        {
            //campos de la clase concreta transferencia
            this.NumeroTransferencia = generarNumeroTransferencia();
            this.CuentaDestino = cuentaDestino;
            this.Categoria = categoria;

            //campos de la clase abstracta Operacion            
            this.TipoOperacion = Operacion.TipoDeOperacion.Transferencia;
            this.Fecha = DateTime.Now;
            this.Monto = monto;
            this.Cuenta = cuentaOrigen;
        }

        private string generarNumeroTransferencia()
        {
            //aca algoritmo para generar el siguiente numero de transferencia (es necesario consultar la BD)
            Random rnd = new Random();
            return rnd.Next(1, 1000000).ToString();
        }

        public static Transferencia ensamblarTransferencia(List<string> ensamblador)
        {
            GestorCuenta gestorCuenta = new GestorCuenta();

            Transferencia t = new Transferencia();

            t.Cuenta = gestorCuenta.TraerCuenta(ensamblador[3]);
            t.CuentaDestino = gestorCuenta.TraerCuenta(ensamblador[7]);
            t.Monto = float.Parse(ensamblador[1]);
            t.Categoria = CategoriaTransferencia.Alquiler; //ESTO ES PROVISORIO, AQUI SE DEBE HACER UN SWITCH
            t.Fecha = DateTime.ParseExact(ensamblador[2], "yyyy/MM/dd", CultureInfo.InvariantCulture);
            t.TipoOperacion = Operacion.TipoDeOperacion.Transferencia;
            t.NumeroTransferencia = ensamblador[6];

            return t;
        }



        /*    public static Transferencia generarTransferencia(string cvuOrigen , string cvuDestino , string monto, string referencia, CategoriaTransferencia concepto)
            {
                CuentaDAO cuentaDAO = new CuentaDAO();
                Cuenta cuentaOrigen = Cuenta.crearCuentaConCVU(cvuOrigen);
                Cuenta cuentaDestino = Cuenta.crearCuentaConCVU(cvuDestino);
                cuentaOrigen = cuentaDAO.consultar(cuentaOrigen);
                cuentaDestino = cuentaDAO.consultar(cuentaDestino);

                Transferencia t = new Transferencia(cuentaDestino, cuentaOrigen, float.Parse(monto), referencia, concepto);

                return t;

            }*/
    }
}
 