using System.Collections.Generic;

namespace Backend_Clip
{
    public class TipoCuenta
    {
        private static int ID;
        private string nombre, descripcion;
        //En nombre va: Pesos, Moneda Extranjera o Criptomoneda.
        //En descripcion va una breve descripción del tipo de cuenta
        
        //el array de tipos de cuenta se recupera de la BD
        private static List<TipoCuenta> tiposDeCuentas = new List<TipoCuenta>();
        public static List<TipoCuenta> TiposDeCuentas { get => tiposDeCuentas; }
                
        private static TipoCuenta cuentaDeAhorros = new TipoCuenta("Cuenta de Ahorros", "Cuenta basica que no permite girar al descubierto");
        
        public static TipoCuenta ObtenerCuentaDeAhorros()
        {
            return cuentaDeAhorros;
        }

        //el constructor es privado, porque los tipos de cuenta no se van a crear, son una cantidad fija(?
        private TipoCuenta(string nombre, string descripcion)
        {
            ++ID;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}
