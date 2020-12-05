using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{
    public class Transferencia : Operacion
    {
        public enum ConceptoTransferencia { Varios, Alquiler, AportesDeCapital, Expensas, Factura, Haberes, Honorarios, Prestamo, Seguro, Cuota };

        public string NumeroTransferencia { get; protected set; }
        public Cuenta CuentaDestino { get; protected set; }
        public string ReferenciaDestino { get; protected set; }
        public ConceptoTransferencia Concepto { get; protected set; }

        public Transferencia(Cuenta cuentaDestino, Cuenta cuentaOrigen, float monto, string referenciaDestino, ConceptoTransferencia concepto) 
        {
            //campos de la clase concreta transferencia
            this.NumeroTransferencia = GenerarNumeroTransferencia();
            this.CuentaDestino = cuentaDestino;
            this.ReferenciaDestino = referenciaDestino;
            this.Concepto = concepto;

            //campos de la clase abstracta Operacion            
            this.TipoOperacion = Operacion.TipoDeOperacion.Transferencia;
            this.Fecha = DateTime.Now;
            this.Monto = monto;
            this.Cuenta = cuentaOrigen;
        }

        private string GenerarNumeroTransferencia()
        {
            //aca algoritmo para generar el siguiente numero de transferencia (es necesario consultar la BD)
            Random rnd = new Random();
            return rnd.Next(1, 10000).ToString();
        }
    }
}
 