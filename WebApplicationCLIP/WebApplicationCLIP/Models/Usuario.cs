using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{

    public class Usuario
    {
        public string Dni { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string SitCrediticia { get; private set; }
        public string NombreDeUsuario { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public string Contraseña { get; private set; }
        public static Usuario prueba()
        {
            return new Usuario()
            {
                Dni = "12345678"
            };
        }
               
         private Usuario(string dni, string nombre, string apellido, string sitCrediticia, string nombreDeUsuario, string email, string telefono, string contraseña)
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

        private Usuario() { }

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

        public static Usuario CrearUsuarioConJObject(JObject usuarioJSON)
        {
            Usuario usuario = new Usuario()
            {
                Nombre = (string)usuarioJSON["Nombre"],
                Apellido = (string)usuarioJSON["Apellido"],
                Dni = (string)usuarioJSON["Dni"],
                NombreDeUsuario = (string)usuarioJSON["NombreDeUsuario"],
                Email = (string)usuarioJSON["Email"],
                SitCrediticia = (string)usuarioJSON["SitCrediticia"],
                Telefono = (string)usuarioJSON["Telefono"],
                Contraseña = (string)usuarioJSON["Contraseña"],

            };
            return usuario;
        }

        public static Usuario ensablarUsuario(List<string> ensamblador)
        {
            Usuario usuario = new Usuario();

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
        {//            Usuario usuario = new Usuario("", "", "", "", "", "", "", "");
            Usuario usuario = new Usuario();
            usuario.NombreDeUsuario = nombreDeUsuario;
            return usuario;
        }       
        

        public static Usuario CrearUsuarioConDNI(string DNI) 
        {
            Usuario usuario = new Usuario();
            usuario.Dni = DNI;
            return usuario;
        }

        public static Usuario nuevoUsuario(string dni, string nombre, string apellido, string nombreDeUsuario, string email, string telefono, string contraseña) 
        {
            //    Usuario usuarioNuevo = new Usuario(dni, nombre, apellido, "normal", nombreDeUsuario, email.ToLower(), telefono, contraseña);

            Usuario usuarioNuevo = new Usuario()
            {
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                NombreDeUsuario = nombreDeUsuario,
                Email = email,
                Telefono = telefono,
                Contraseña = contraseña
            };

            return usuarioNuevo;
        }

    }
}