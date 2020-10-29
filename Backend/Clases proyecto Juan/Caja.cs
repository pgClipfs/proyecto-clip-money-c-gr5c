using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoClip
{
    class Caja
    {
        private Moneda moneda;
        private double saldo;
        private int numeroDeCaja;

        public Caja(Moneda tipoMoneda, double saldo, int numeroDeCaja)
        {
            this.moneda = tipoMoneda;
            this.Saldo = saldo;
            this.NumeroDeCaja = numeroDeCaja;
        }

        public double Saldo { get => saldo; set => saldo = value; }
        public int NumeroDeCaja { get => numeroDeCaja; set => numeroDeCaja = value; }

        public string DevolverTipoMoneda()
        {
            return moneda.NombreMoneda;
        }
    }
}
