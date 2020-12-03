using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{
    public class Transferencia : Operacion
    {
        public enum ConceptoTransferencia { Varios, Alquiler, AportesDeCapital, Expensas, Factura, Haberes, Honorarios, Prestamo, Seguro, Cuota };

        private string numeroTransferencia;
        private Cuenta cuentaDestino;
        private string referenciaDestino;
        private ConceptoTransferencia concepto;

        public string NumeroTransferencia { get => numeroTransferencia; }
        public Cuenta CuentaDestino { get => cuentaDestino;  }
        public string ReferenciaDestino { get => referenciaDestino; }
        public ConceptoTransferencia Concepto { get => concepto;  }                          

        public Transferencia(Cuenta cuentaDestino, Cuenta cuentaOrigen, float monto, string referenciaDestino, ConceptoTransferencia concepto) 
        {
            //campos de la clase concreta transferencia
            this.numeroTransferencia = GenerarNumeroTransferencia();
            this.cuentaDestino = cuentaDestino;
            this.referenciaDestino = referenciaDestino;
            this.concepto = concepto;

            //campos de la clase abstracta Operacion            
            this.TipoOperacion = Operacion.TipoDeOperacion.Transferencia;
            this.Fecha = DateTime.Now;

        }

        private string GenerarNumeroTransferencia()
        {
            //aca algoritmo para generar el siguiente numero de transferencia (es necesario consultar la BD)
            Random rnd = new Random();
            return rnd.Next(1, 10000).ToString();
        }
    }
}
 