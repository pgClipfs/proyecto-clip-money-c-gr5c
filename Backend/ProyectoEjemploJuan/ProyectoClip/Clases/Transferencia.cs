using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoClip.Clases
{
    class Transferencia
    {
        private string nombre;
        private Cuenta cuentaOrigen;
        private Cuenta cuentaDestino;
        private double montoAtransferir;
        private Moneda tipoMoneda;
        private DateTime fechaOperacion;

        public string Nombre { get => nombre; set => nombre = value; }
        public double MontoAtransferir { get => montoAtransferir; set => montoAtransferir = value; }
        public DateTime FechaOperacion { get => fechaOperacion; }

        public Transferencia(Cuenta cuentaOrigen, Cuenta cuentaDestino, double montoAtransferir, Moneda tipoMoneda)
        {
            this.nombre = "Transferencia";
            this.cuentaOrigen = cuentaOrigen;
            this.cuentaDestino = cuentaDestino;
            this.montoAtransferir = montoAtransferir;
            this.tipoMoneda = tipoMoneda;
            this.fechaOperacion = DateTime.Now;
        }

        public void transferir()
        {
            cuentaOrigen.DisminuirSaldoCajaEnPesos(montoAtransferir);
            cuentaDestino.AumentarSaldoCajaEnPesos(montoAtransferir);
        }
    }
}
