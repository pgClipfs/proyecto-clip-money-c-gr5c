using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoClip
{
    class Deposito
    {
        private  string nombre;
        private Cuenta cuenta;
        private double monto;
        private Moneda tipoMoneda;
        private DateTime fechaOperacion;

        public Deposito(Cuenta cuenta, double montoDinero, Moneda tipoMoneda)
        {
            this.cuenta = cuenta;
            this.monto = montoDinero;
            this.tipoMoneda = tipoMoneda;
            this.nombre = "Deposito";
            this.fechaOperacion = DateTime.UtcNow;
        }

        public double Monto { get => monto; set => monto = value; }
        public DateTime FechaOperacion { get => fechaOperacion;  }
        public string Nombre { get => nombre;  }

        public void realizar()
        {
           if (tipoMoneda.NombreMoneda == "Pesos Argentinos")
            {
                cuenta.AumentarSaldoCajaEnPesos(monto);
            }
        }
    }
}
