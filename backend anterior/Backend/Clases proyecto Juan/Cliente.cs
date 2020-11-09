using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProyectoClip.Clases;

namespace ProyectoClip
{
    class Cliente
    {
        private string nombre;
        private string apellido;
        private TipoDocumento tipoDocumento;
        private string email;
        private Cuenta cuenta;
        private string estadoCrediticio;

        public Cliente(string nombre, string apellido, TipoDocumento tipoDocumento, string email, Cuenta cuenta, string estadoCrediticio)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.TipoDocumento = tipoDocumento;
            this.Email = email;
            this.Cuenta = cuenta;
            this.EstadoCrediticio = estadoCrediticio;
        }

        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string EstadoCrediticio { get => estadoCrediticio; set => estadoCrediticio = value; }
        internal TipoDocumento TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        internal Cuenta Cuenta { get => cuenta; set => cuenta = value; }
        
        public double ObtenerNumeroCuenta()
        {
            return cuenta.Cvu;
        }
    }
}
