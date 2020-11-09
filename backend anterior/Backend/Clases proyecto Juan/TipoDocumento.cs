using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoClip.Clases
{
    class TipoDocumento
    {
        private string nombre;
        private string descripcion;

        public TipoDocumento(string nombre, string descripcion)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
