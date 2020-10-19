namespace ProyectoCLIPMoney
{
    public class Cuenta
    {
        private int CVU;
        private double saldo;
        private string divisa;        
        //Monedas válidas: 
        //Para Pesos: Peso argentino.
        //Para Moneda Extranjera: Dolar estadounidense, Euro.
        //Para Criptomoneda: Ethereum, Bitcoin, Litecoin.
        private TipoCuenta tipoCuenta;
        private Usuario usuario;

        public Cuenta(int CVU, double saldo, string divisa, TipoCuenta tipoCuenta, Usuario usuario)
        {
            this.CVU = CVU;
            this.saldo = saldo;
            this.tipoCuenta = tipoCuenta;
            this.usuario = usuario;
        }
        public void ActualizarSaldo(double nuevoSaldo)
        {
            saldo = nuevoSaldo;
        }
        public double ConsultarSaldo()
        {
            return saldo;
        }
        public TipoCuenta TipoDeCuenta()
        {
            return tipoCuenta;
        }
        public string GetDivisa()
        {
            return divisa;
        }
        public Usuario GetUsuario()
        {
            return usuario;
        }
    }
}
