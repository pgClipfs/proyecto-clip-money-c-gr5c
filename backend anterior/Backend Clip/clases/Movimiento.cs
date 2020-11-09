using System;
namespace Backend_Clip
{
    public class Movimiento
    {

        private static int ultimaID = 0;
        public enum Tipo {Depósito,Extracción};

        private int id;
        private Tipo tipoMovimiento;
        private DateTime fecha; //fecha en la que se realizó el movimiento
        private double monto; //cantidad de dinero a Ingresar o Retirar de la cuenta
        private Cuenta cuentaAsociada;

        public int ID { get => id; }
        public Tipo TipoMovimiento { get => tipoMovimiento; }
        public DateTime Fecha { get => fecha; }
        public double Monto { get => monto; }
        public Cuenta CuentaAsociada { get => cuentaAsociada; }

        private int generarID()
        {
            ++ultimaID;
            return ultimaID;
        }

        public Movimiento(Tipo tipoMovimiento, double monto, Cuenta cuentaAsociada)
        {
            fecha = DateTime.Now;

            this.id = generarID();
            this.tipoMovimiento = tipoMovimiento;
            this.monto = monto;
            this.cuentaAsociada = cuentaAsociada;

            //guardar en la BD? el movimiento se guarda a si mismo en la base de datos???
         }
  
    }
}
