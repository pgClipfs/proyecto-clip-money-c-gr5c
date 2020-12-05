using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{
    abstract public class Operacion 
    {
        public enum TipoDeOperacion { Transferencia, Deposito, Extracion, GiroAlDescubierto };
                
        /*
         * poniendo "protected" adelante de los set, se logra que esas propiedades puedan ser modificadas por
         * las clases que la heredan (ej, transferencia), pero no pueden ser modificadas por otra clase. y la 
         * propiedad es visible para todas las clases, cualquier clase puede conocer el valor de estas propiedades, 
         * pero solo las que heredan la pueden modificar 
         */
        
        public TipoDeOperacion TipoOperacion { get; protected set; }
        public float Monto { get; protected set; }
        public DateTime Fecha { get ; protected set ; }
        public Cuenta Cuenta { get; protected set; }
        public string IdOperacion { get; protected set; }

        public static string GenerarIdOperacion()
        {
            //aca algoritmo para generar el siguiente numero de operacion (es necesario consultar la BD)
            Random rnd = new Random();
            return rnd.Next(1, 10000).ToString();
        }
    }
}