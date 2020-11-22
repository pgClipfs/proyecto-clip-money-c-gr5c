using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{
    public class Usuario
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string SitCrediticia { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }

        //este va si o si
        public Usuario(string dni, string nombre, string apellido, string sitCrediticia, string nombreDeUsuario, string email, string telefono, string contraseña)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            SitCrediticia = sitCrediticia;
            NombreDeUsuario = nombreDeUsuario;
            Email = email.ToLower();
            Telefono = telefono;
            Contraseña = contraseña;
        }

        public static Usuario ensablarUsuario(List<string> ensamblador, Usuario usuario)
        {
            usuario.Dni = ensamblador[0];
            usuario.Nombre = ensamblador[1];
            usuario.Apellido = ensamblador[2];
            usuario.SitCrediticia = ensamblador[3];
            usuario.NombreDeUsuario = ensamblador[4];
            usuario.Email = ensamblador[5].ToLower();
            usuario.Telefono = ensamblador[6];
            usuario.Contraseña = ensamblador[7];

            return usuario;
        }

        public static Usuario ensablarUsuario(List<string> ensamblador)
        {
            Usuario usuario = new Usuario("", "", "", "", "", "", "", "");

            try
            {
                usuario.Dni = ensamblador[0];
              usuario.Nombre = ensamblador[1];
              usuario.Apellido = ensamblador[2];
              usuario.SitCrediticia = ensamblador[3];
              usuario.NombreDeUsuario = ensamblador[4];
              usuario.Email = ensamblador[5].ToLower();
            usuario.Telefono = ensamblador[6];
            usuario.Contraseña = ensamblador[7];
            }
            catch (Exception e)
            {
                Console.WriteLine("Parametros invalidos para ensamblar el Usuario --> " + e.Message);
           }
            return usuario;
        }

     
        public static Usuario CrearUsuarioConNombreDeUsuario(string nombreDeUsuario)
        {
            Usuario usuario = new Usuario("", "", "", "", "", "", "", "");
            usuario.NombreDeUsuario = nombreDeUsuario;
            return usuario;

        }
               

        public static Usuario nuevoUsuario(string dni, string nombre, string apellido, string nombreDeUsuario, string email, string telefono, string contraseña) 
        {
            Usuario usuarioNuevo = new Usuario(dni, nombre, apellido, "normal", nombreDeUsuario, email.ToLower(), telefono, contraseña);
            return usuarioNuevo;
        }

    }
}