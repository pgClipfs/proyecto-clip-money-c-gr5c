using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoClip
{
    class Extraccion
    {
        private string nombre;
        private Cuenta cuenta;
        private double monto;
        private Moneda tipoMoneda;
        private DateTime fechaOperacion;

        public Extraccion(Cuenta cuenta, double monto, Moneda tipoMoneda)
        {
            this.cuenta = cuenta;
            this.Monto = monto;
            this.tipoMoneda = tipoMoneda;
            this.nombre = "Extraccion";
            this.fechaOperacion = DateTime.UtcNow;
    }

        public string Nombre { get => nombre; }
        public double Monto { get => monto; set => monto = value; }
        public DateTime FechaOperacion { get => fechaOperacion;}

        public void realizar()
        {          
       
            if (tipoMoneda.NombreMoneda == "Pesos Argentinos")
            {
                cuenta.DisminuirSaldoCajaEnPesos(monto);
            }
        }


    }
}
