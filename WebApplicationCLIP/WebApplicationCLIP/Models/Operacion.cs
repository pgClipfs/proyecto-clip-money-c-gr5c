using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{
    abstract public class Operacion 
    {
        public enum TipoDeOperacion { Transferencia, Deposito, Extracion, GiroAlDescubierto };

        private TipoDeOperacion tipoOperacion;
        private float monto;
        private DateTime fecha;
        private Cuenta cuenta;
        private string idOperacion;

        /*
         * poniendo "protected" adelante de los set, se logra que esas propiedades puedan ser modificadas por
         * las clases que la heredan (ej, transferencia), pero no pueden ser modificadas por otra clase. y la 
         * propiedad es visible para todas las clases, cualquier clase puede conocer el valor de estas propiedades, 
         * pero solo las que heredan la pueden modificar 
         */
        
        public TipoDeOperacion TipoOperacion { get => tipoOperacion; protected set => tipoOperacion = value; }
        public float Monto { get => monto; protected set => monto = value; }
        public DateTime Fecha { get => fecha; protected set => fecha = value; }
        public Cuenta Cuenta { get => cuenta; protected set => cuenta = value; }
        public string IdOperacion { get => idOperacion; protected set => idOperacion = value; }

        public static string GenerarIdOperacion()
        {
            //aca algoritmo para generar el siguiente numero de operacion (es necesario consultar la BD)
            Random rnd = new Random();
            return rnd.Next(1, 10000).ToString();
        }
    }
}