namespace ProyectoCLIPMoney
{
    public class TipoCuenta
    {
        private static int ID;
        private string nombre, descripcion;
        //En nombre va: Pesos, Moneda Extranjera o Criptomoneda.
        //En descripcion va una breve descripción del tipo de cuenta
        //En moneda va el tipo de moneda que manejará la cuenta.

        public TipoCuenta(string nombre, string descripcion)
        {
            ++ID;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}
