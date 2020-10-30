using System;
namespace Backend_Clip
{
    public class Transferencia
    {
        private static int nroTransaccion = 0;
        private double monto;
        private DateTime fecha;
        private Cuenta cuentaAsociada;
        private Cuenta cuentaDestino;
        public Transferencia(Cuenta ca, Cuenta cd, double monto)
        {
            cuentaAsociada = ca;
            cuentaDestino = cd;
            this.monto = monto;
        }
        public void Transferir()
        {
            ++nroTransaccion;
            fecha = DateTime.Now;
            //    double saldoCa = cuentaAsociada.ConsultarSaldo();
            //    double saldoCd = cuentaDestino.ConsultarSaldo();
            //    cuentaAsociada.ActualizarSaldo(saldoCa - monto);
            //    cuentaDestino.ActualizarSaldo(saldoCd + monto);

            //Console.WriteLine("¡Transferencia realizada con éxito! " + cuentaAsociada.GetUsuario().GetNombre() + " le transfirió $" +monto+ " a " +cuentaDestino.GetUsuario().GetNombre());
            Console.WriteLine("Número de transacción: " + nroTransaccion);
            Console.WriteLine("Fecha y hora: " + fecha);
            Console.ReadLine();
        }
        public int GetNroTransaccion()
        {
            return nroTransaccion;
        }
        public DateTime GetFecha()
        {
            return fecha;
        }
    }
}
