using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{
    public class SolicitudLogin
    {
        public SolicitudLogin(string contraseña, string nombreDeUsuario)
        {
            NombreDeUsuario = nombreDeUsuario;
            Contraseña = contraseña;
        }

        public string NombreDeUsuario { get; set; }
        public string Contraseña { get; set; }
    }
} 