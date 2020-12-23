using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{
     public class Operacion 
    {
        public static List<Operacion> ObtenerOperacionesDePrueba()
        {
            List<Operacion> lista = new List<Operacion>();

            Operacion op1 = new Operacion()
            {
                Monto = 1000,
                IdOperacion = "001",
                Fecha = DateTime.Now,
                TipoOperacion = TipoDeOperacion.Deposito
            };
            Operacion op2 = new Operacion()
            {
                Monto = 2000,
                IdOperacion = "020",
                Fecha = DateTime.Now,
                TipoOperacion = TipoDeOperacion.Extracion
            };
            Operacion op3 = new Operacion()
            {
                Monto = 3000,
                IdOperacion = "300",
                Fecha = DateTime.Now,
                TipoOperacion = TipoDeOperacion.Transferencia
            };

            lista.Add(op1);
            lista.Add(op2);
            lista.Add(op3);
            return lista;
        }


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