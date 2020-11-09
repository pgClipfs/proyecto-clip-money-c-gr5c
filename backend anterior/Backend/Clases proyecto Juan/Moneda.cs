using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoClip
{
    class Moneda
    {
        private string nombreMoneda;
        private double cotizacion;

        public Moneda(string nombreMoneda, double cotizacion)
        {
            this.NombreMoneda = nombreMoneda;
            this.Cotizacion = cotizacion;
        }

        public string NombreMoneda { get => nombreMoneda; set => nombreMoneda = value; }
        public double Cotizacion { get => cotizacion; set => cotizacion = value; }
    }
}
