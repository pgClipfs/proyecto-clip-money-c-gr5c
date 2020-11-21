using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{
    public class Usuario
    {
        public Usuario(string dni, string nombre, string apellido, string sitCrediticia, string nombreDeUsuario, string email, string telefono, string contraseña)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            SitCrediticia = sitCrediticia;
            NombreDeUsuario = nombreDeUsuario;
            Email = email;
            Telefono = telefono;
            Contraseña = contraseña;
        }

        public Usuario(List<string> ensamblador)
        {
            try
            {
                Dni = ensamblador[0];
                Nombre = ensamblador[1];
                Apellido = ensamblador[2];
                SitCrediticia = ensamblador[3];
                NombreDeUsuario = ensamblador[4];
                Email = ensamblador[5];
                Telefono = ensamblador[6];
                Contraseña = ensamblador[7];
            }
            catch (Exception e)
            {
                Console.WriteLine("Parametros invalidos para ensamblar el Usuario --> " + e.Message);
            }
        }

        public Usuario(string nombreUsuario)
        {
            Dni = "";
            Nombre = "";
            Apellido = "";
            SitCrediticia = "";
            NombreDeUsuario = nombreUsuario;
            Email = "";
            Telefono = "";
            Contraseña = "";
        }

        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string SitCrediticia { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }


        public static Usuario nuevoUsuario(string dni, string nombre, string apellido, string nombreDeUsuario, string email, string telefono, string contraseña) 
        {
            Usuario usuarioNuevo = new Usuario(dni, nombre, apellido, "normal", nombreDeUsuario, email, telefono, contraseña);
            return usuarioNuevo;
        }

    }
}