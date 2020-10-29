using System;

namespace ProyectoCLIPMoney
{
    public class Cuenta
    {  
        //Monedas válidas: 
        //Para Pesos: Peso argentino.
        //Para Moneda Extranjera: Dolar estadounidense, Euro.
        //Para Criptomoneda: Ethereum, Bitcoin, Litecoin.
        
        #region propiedades
        
        //son todas de lectura porque ninguno de estos atributos se deberia modificar desde fuera de la clase
        public int CVU { get => CVU; }
        public double Saldo { get => saldo; }
        public Divisa Divisa { get => divisa; }
        public TipoCuenta TipoCuenta { get => tipoCuenta;  }
        public Usuario Usuario { get => usuario; }
        
        #endregion

        private int cvu;
        private double saldo;
        private Divisa divisa;        
        private TipoCuenta tipoCuenta;
        private Usuario usuario;
                       
        public Cuenta(Divisa divisa, TipoCuenta tipoCuenta, Usuario usuario, int cvu = 0)
        {
            this.divisa = divisa;
            this.tipoCuenta = tipoCuenta;
            this.usuario = usuario;

            if (cvu==0)
            {
            this.cvu = Cuenta.GenerarCVU();
            }
            else
            {
            this.cvu = cvu;
            }
            this.saldo = 0;
        }

        private static int GenerarCVU()
        {
            //no se q parametros tomaria, por ahora solo devuelve un aleatorio
            Random random = new Random();
            return random.Next();
        }

        public void EliminarCuenta()
        {
            //este metodo necesita acceder a la BD para borrar la cuenta
        }
               
    }
}
