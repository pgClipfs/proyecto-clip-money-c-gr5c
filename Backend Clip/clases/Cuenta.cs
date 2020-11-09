using System;

namespace Backend_Clip
{
    public class Cuenta
    {  
        //Monedas válidas: 
        //Para Pesos: Peso argentino.
        //Para Moneda Extranjera: Dolar estadounidense, Euro.
        //Para Criptomoneda: Ethereum, Bitcoin, Litecoin.
        
        #region propiedades
        
        //son todas de lectura porque ninguno de estos atributos se deberia modificar desde fuera de la clase
        public int CVU { get => cvu; }
        public double Saldo { get => saldo; }
        public Divisa Divisa { get => divisa; }
        public TipoCuenta TipoCuenta { get => tipoCuenta;  }
        public Usuario Usuario { get => usuario; }

        #endregion

        public override string ToString()
        {
            return "cvu: " + cvu.ToString() + ", saldo: " + saldo + ", divisa: " + divisa + ", tipo cuenta: " + tipoCuenta + ", usuario: " + usuario.Nombre + " " + usuario.Apellido;
        }

        private int cvu;
        private double saldo;
        private Divisa divisa;        
        private TipoCuenta tipoCuenta;
        private Usuario usuario;
                       
        public Cuenta(Divisa divisa, TipoCuenta tipoCuenta, Usuario usuario, int cvu = 0)
        {
            this.divisa = divisa;
            this.tipoCuenta = tipoCuenta;
            this.usuario = usuario;

            if (cvu==0)
            {
            this.cvu = Cuenta.GenerarCVU();
            }
            else
            {
            this.cvu = cvu;
            }
            this.saldo = 0;
        }

        private static int GenerarCVU()
        {
            //no se q parametros tomaria, por ahora solo devuelve un aleatorio
            Random random = new Random();
            return random.Next(1,99999);
        }

        private void GuardarMovimiento()
        {
            /*no necesariamente tiene que tener este nombre o esos parametros, pero esta funcion lo que hace es guardar el movimiento que se acaba de realizar, en la BD*/
        }

        public void Depositar(float monto)
        {
            saldo += monto;

            //y que se hace con este objeto "movimiento" que se genera? se guarda solo en la BD?
            Movimiento movimiento = new Movimiento(Movimiento.Tipo.Depósito, monto, this);

            //algun mensaje o devolucion???
        }

        public void Extraer(float monto) 
        {            
            if (monto>saldo)
            {
                Console.WriteLine("monto a extraer mayor que el saldo disponible");
                throw new MontoMayorAlSaldo();
            }
            else
            {
                saldo += monto;
                Movimiento movimiento = new Movimiento(Movimiento.Tipo.Extracción, monto, this);
            }
        }   

        public void EliminarCuenta()
        {
            //este metodo necesita acceder a la BD para borrar la cuenta
        }

        public void GirarAlDescubierto()
        {
            /*hay que hacer una clase "cuenta" padre, y los tipos de cuenta que hereden de
             esa, pero que tengan diferente comportamiento (como lo de girar al descubierto)
             o se maneja todo en una misma clase??? */
        }
               
    }

    [Serializable]
    class MontoMayorAlSaldo : Exception
    {
        public MontoMayorAlSaldo()
            : base(String.Format("El monto que intenta extraer es mayor al saldo disponible "))
        {

        }

    }
}
