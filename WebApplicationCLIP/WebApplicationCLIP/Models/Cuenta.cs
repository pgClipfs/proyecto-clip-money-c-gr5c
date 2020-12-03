using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{
    public class Cuenta
    {
        private string cvu;
        private Usuario usuario;
        private float saldo;
        private List<Operacion> operaciones;

        public string Cvu { get => cvu; set => cvu = value; }
        public Usuario Usuario { get => usuario; set => usuario = value; }
        public float Saldo { get => saldo; set => saldo = value; }
        public List<Operacion> Operaciones { get => operaciones; set => operaciones = value; }
                
        public Cuenta(string cvu, Usuario usuario)
        {
            this.cvu = cvu;
            this.usuario = usuario;
            this.saldo = 0;
            this.operaciones = new List<Operacion>();
        }

        public void Transferir(Cuenta cuentaDestino, float monto)
        {
            //no se si tiene que devolver void
            Transferencia transferencia = new Transferencia(null, null, monto, null,Transferencia.ConceptoTransferencia.Varios);

        }

        public void Depositar(float monto)
        {
            //no se si tiene que devolver void
        }

        public void Extraer(float monto)
        {
            //no se si tiene que devolver void
        }
    }
}