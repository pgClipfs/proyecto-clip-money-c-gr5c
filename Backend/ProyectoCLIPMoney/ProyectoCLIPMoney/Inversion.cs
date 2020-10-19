using System;
namespace ProyectoCLIPMoney
{
    public class Inversion
    {
        private int ID;
        private Cuenta cuentaAsociada;
        private double monto;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private TipoInversion tipoInversion;


        public Inversion(int ID, Cuenta cuentaAsociada, double monto, TipoInversion tipoInversion)
        {
            this.ID = ID;
            this.cuentaAsociada = cuentaAsociada;
            this.monto = monto;
            fechaInicio = DateTime.Now;
            this.tipoInversion = tipoInversion;
        }

        public void Invertir()
        {
        }

        public void IngersarFCI()
        {
        }
        public void UltimasOperaciones()
        {
        }
    }
}
