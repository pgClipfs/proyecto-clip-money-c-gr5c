using System;
using System.Collections.Generic;
using System.Text;

namespace Backend_Clip
{
    public class TipoInversion
    {
        private string nombre;
        private string descripcion;

        public TipoInversion(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
