using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{
    public class SesionDeUsuario
    {
        public SesionDeUsuario(string nombreDeUsuario, string token)
        {
            this.NombreDeUsuario = nombreDeUsuario;
            this.Token = token;
        }

        public string NombreDeUsuario { get; set; }
        public string Token { get; set; }
    }
}