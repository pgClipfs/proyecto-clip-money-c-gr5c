using System;
namespace ProyectoCLIPMoney
{
    public class Movimiento
    {
        private static int ID = 0;
        private DateTime fecha; //fecha en la que se realizó el movimiento
        private char tipoMovimiento; //2 tipos de mov: I para Ingresar Dinero, R para Retirar Dinero
        private double monto; //cantidad de dinero a Ingresar o Retirar de la cuenta
        private Cuenta cuentaAsociada;
        public Movimiento(char tipoMovimiento, double monto, Cuenta cuentaAsociada)
        {
            fecha = DateTime.Now;
            ++ID;
            while (tipoMovimiento != 'I' && tipoMovimiento != 'R')
            {
                Console.WriteLine("La letra ingresada no corresponde a ninguno de los 2 movimientos válidos. Intente nuevamente.");
                Console.Write("Escriba I para ingresar dinero o R para retirar dinero: ");
                string linea = Console.ReadLine();
                tipoMovimiento = Convert.ToChar(linea);
                this.tipoMovimiento = tipoMovimiento;
                Console.WriteLine();
            }
            this.tipoMovimiento = tipoMovimiento;
            this.monto = monto;
            this.cuentaAsociada = cuentaAsociada;
            RealizarMovimiento();
        }
        private void RealizarMovimiento()
        {
            double saldo = cuentaAsociada.ConsultarSaldo();
            if (tipoMovimiento == 'I')
            {
                if (monto > 0)
                {
                    saldo = saldo + monto;
                    Console.WriteLine("¡Deposito realizado con éxito! "+cuentaAsociada.GetUsuario().GetNombre()+", tu saldo acutal es: " + saldo);
                    Console.WriteLine("ID de la operación: " + ID);
                    cuentaAsociada.ActualizarSaldo(saldo);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("El monto que quiere sumar es negativo, error. Intente de nuevo.");
                    Console.ReadLine();
                }
            }
            else
            {
                if ((saldo - monto) >= 0)
                {
                    saldo = saldo - monto;
                    Console.WriteLine("¡Extracción realizada con éxito!  "+cuentaAsociada.GetUsuario().GetNombre()+", tu saldo acutal es: " + saldo);
                    Console.WriteLine("ID de la operación: " + ID);
                    cuentaAsociada.ActualizarSaldo(saldo);
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("El monto que quiere retirar es mayor al saldo actual. Por favor, pruebe con otro monto.");
                    Console.ReadLine();
                }
            }
        }
        public void GirarAlDescubierto()
        {
            if (cuentaAsociada.GetDivisa() == "Peso argentino")
            {
                //if()
            }
            else
            {
                Console.WriteLine("Operación inválida.");
                Console.WriteLine("Para realizar esta operación su cuenta debe manejar pesos argentinos.");
                Console.ReadLine();
            }
        }
    }
}
