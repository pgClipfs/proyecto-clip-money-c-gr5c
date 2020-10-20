using System;

namespace ProyectoCLIPMoney
{
    public class Cuenta
    {  
        //Monedas válidas: 
        //Para Pesos: Peso argentino.
        //Para Moneda Extranjera: Dolar estadounidense, Euro.
        //Para Criptomoneda: Ethereum, Bitcoin, Litecoin.

        private int cvu;
        private double saldo;
        private Divisa divisa;        
        private TipoCuenta tipoCuenta;
        private Usuario usuario;

        public int CVU { get => CVU; }
        public double Saldo { get => saldo; }
        public Divisa Divisa { get => divisa; }
        public TipoCuenta TipoCuenta { get => tipoCuenta;  }
        public Usuario Usuario { get => usuario; }

        public Cuenta(double saldo, Divisa divisa, TipoCuenta tipoCuenta, Usuario usuario,int cvu)
        {
            this.cvu = cvu;
            this.saldo = saldo;
            this.tipoCuenta = tipoCuenta;
            this.usuario = usuario;
        }

        //sobrecarga para generar el CVU automaticamente
        public Cuenta(double saldo, Divisa divisa, TipoCuenta tipoCuenta, Usuario usuario)
        {
            this.cvu = Cuenta.GenerarCVU();
            this.saldo = saldo;
            this.tipoCuenta = tipoCuenta;
            this.usuario = usuario;
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

        /* esta la comento porque el saldo solo se deberia actualizar mediante 
         * operaciones (por ej, transferencias, depositos, etc), nunca de una forma "manual"
         
        public void ActualizarSaldo(double nuevoSaldo)
        {
            saldo = nuevoSaldo;
        }*/


    }
}
