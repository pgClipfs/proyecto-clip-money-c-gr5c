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
            //this.CuentaDestino = null;
            CuentaDestino.BorrarDatosEscenciales();
            Cuenta.BorrarDatosEscenciales();
        }

        public enum CategoriaTransferencia { Varios, Alquiler, AportesDeCapital, Expensas, Factura, Haberes, Honorarios, Prestamo, Seguro, Cuota };

        public string NumeroTransferencia { get; protected set; }
        public Cuenta CuentaDestino { get; protected set; }
        public string ReferenciaDestino { get; protected set; }
        public CategoriaTransferencia Categoria { get; protected set; }

        public Transferencia()
        {

        }

        public Transferencia(Cuenta cuentaDestino, Cuenta cuentaOrigen, float monto, string referencia, CategoriaTransferencia categoria)
        {
            //campos de la clase concreta transferencia
            this.NumeroTransferencia = generarNumeroTransferencia();
            this.CuentaDestino = cuentaDestino;
            this.Categoria = categoria;
            this.ReferenciaDestino = referencia;

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

            //cosas de la transferencia
            t.Cuenta = gestorCuenta.TraerCuenta(ensamblador[3]);
            t.CuentaDestino = gestorCuenta.TraerCuenta(ensamblador[7]);
            t.NumeroTransferencia = ensamblador[6];
            t.ReferenciaDestino = ensamblador[9];

            //conversion categoria a enum
            CategoriaTransferencia cat;
            Enum.TryParse(ensamblador[8], out cat);
            t.Categoria = cat;

            //cosas de la operacion
            t.TipoOperacion = Operacion.TipoDeOperacion.Transferencia;
            t.Monto = float.Parse(ensamblador[1]);
            t.Fecha = DateTime.Parse(ensamblador[2]);
            t.IdOperacion = ensamblador[5];

            return t;
        }
                     
    }
}
