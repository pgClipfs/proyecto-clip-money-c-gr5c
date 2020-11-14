using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{
    public class Usuario
    {
        public Usuario(string id, string nombre, string apellido, string dni, string nombreDeUsuario, string contraseña)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            SitCrediticia = null;
            NombreDeUsuario = nombreDeUsuario;
            Contraseña = contraseña;
        }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string SitCrediticia { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }

    }
}