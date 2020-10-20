namespace ProyectoCLIPMoney
{
    public class Divisa
    {
        private string nombre, descripcion;
        private TipoMoneda tipoMoneda;
        public Divisa(TipoMoneda tipoMoneda, string nombre)
        {
            this.tipoMoneda = tipoMoneda;
            this.nombre = nombre;
        }
    }
}