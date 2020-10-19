using System;
namespace ProyectoCLIPMoney
{
    public class CompraVentaDivisa
    {
        private int DNI;
        private Cuenta cuentaOrigen, cuentaDestino;
        private int comision;
        private DateTime fecha;
        public CompraVentaDivisa(int DNI, Cuenta cuentaOrigen, Cuenta cuentaDestino)
        {
            this.DNI = DNI;
            this.cuentaOrigen = cuentaOrigen;
            this.cuentaDestino = cuentaDestino;
        }
        public void ComprarDivisa()
        {

        }
        public void VenderDivisa()
        {

        }
        public void UltimasOperaciones()
        {

        }
    }  
}
