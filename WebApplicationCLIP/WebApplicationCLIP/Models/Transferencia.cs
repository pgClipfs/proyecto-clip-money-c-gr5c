using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationCLIP.BD;

namespace WebApplicationCLIP.Models
{
    public class Transferencia : Operacion
    {
        public enum CategoriaTransferencia { Varios, Alquiler, AportesDeCapital, Expensas, Factura, Haberes, Honorarios, Prestamo, Seguro, Cuota };

        public string NumeroTransferencia { get; protected set; }
        public Cuenta CuentaDestino { get; protected set; }
        public string ReferenciaDestino { get; protected set; }
        public CategoriaTransferencia Categoria { get; protected set; }

        public Transferencia(Cuenta cuentaDestino, Cuenta cuentaOrigen, float monto, CategoriaTransferencia categoria) 
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


        public static Transferencia generarTransferencia(string cvuOrigen , string cvuDestino , CategoriaTransferencia concepto , string monto) 
        {
            CuentaDAO cuentaDAO = new CuentaDAO();
            Cuenta cuentaOrigen = Cuenta.crearCuentaConCVU(cvuOrigen);
            Cuenta cuentaDestino = Cuenta.crearCuentaConCVU(cvuDestino);
            cuentaOrigen = cuentaDAO.consultar(cuentaOrigen);
            cuentaDestino = cuentaDAO.consultar(cuentaDestino);

            Transferencia t = new Transferencia(cuentaDestino, cuentaOrigen, float.Parse(monto), concepto);

            return t;
            
        }
    }
}
 