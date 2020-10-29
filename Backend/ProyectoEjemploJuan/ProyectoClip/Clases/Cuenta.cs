using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoClip.Clases;

namespace ProyectoClip
{
    class Cuenta
    {
        private int cvu;
        private DateTime fechaAlta;
        private EstadoCuenta estadoCuenta;
        private Caja[] cajas;

        public Cuenta(int cvu, DateTime fechaAlta, EstadoCuenta estadoCuenta, Caja[] cajas)
        {
            this.Cvu = cvu;
            this.FechaAlta = fechaAlta;
            this.estadoCuenta = estadoCuenta;
            this.cajas = cajas;
        }

        public int Cvu { get => cvu; set => cvu = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }

        
        public void AumentarSaldoCajaEnPesos(double monto)
        {
            foreach (Caja item in cajas)
            {
                if (item.DevolverTipoMoneda() == "Pesos Argentinos")
                {
                    item.Saldo += monto;
                }
            }
        }
        public void DisminuirSaldoCajaEnPesos( double monto) {
            foreach (Caja item in cajas)
            {
                if (item.DevolverTipoMoneda() == "Pesos Argentinos")
                {
                    item.Saldo -= monto;
                }
            }
        }

        public double ObtenerSaldoCajaPesos()
        {
            foreach (Caja item in cajas)
            {
                if (item.DevolverTipoMoneda() == "Pesos Argentinos")
                {
                    return item.Saldo;
                }
            }
            return 0;
        }

        public double ObtenerNumeroCajaPesos()
        {
            foreach (Caja item in cajas)
            {
                if (item.DevolverTipoMoneda() == "Pesos Argentinos")
                {
                    return item.NumeroDeCaja;
                }
            }
            return 0;
        }
    }
}
