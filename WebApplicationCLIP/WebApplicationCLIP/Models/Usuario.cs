using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationCLIP.BD;
using WebApplicationCLIP.Gestores;

namespace WebApplicationCLIP.Models
{

    public class Usuario
    {
        public string Dni { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string SitCrediticia { get; private set; }
        public string NombreDeUsuario { get; private set; }
        public string Domicilio { get; private set; }
        public string Email { get; private set; }
        public string Telefono { get; private set; }
        public string Contraseña { get; private set; }
  

        public void BorrarDatosEscenciales()
        {
            Contraseña = "";
            Dni = "";
            SitCrediticia = "";
            NombreDeUsuario = "";
            Domicilio = "";
            Telefono = "";
        }

        public void CrearNuevaCuenta()
        {
            bool reintentar = true;

            while (reintentar)
            {
                GestorCuenta gestor = new GestorCuenta();
                Cuenta cuenta = new Cuenta(this);

                try
                {
                    gestor.RegistrarCuenta(cuenta);
                    reintentar = false;
                }

                catch (ErrorCvuRepetido) { }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private Usuario(string dni, string nombre, string apellido, string sitCrediticia, string nombreDeUsuario, string domicilio, string email, string telefono, string contraseña)
        {
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            SitCrediticia = sitCrediticia;
            NombreDeUsuario = nombreDeUsuario;
            Domicilio = domicilio;
            Email = email.ToLower();
            Telefono = telefono;
            Contraseña = contraseña;
        }

        private Usuario() { }

        private static void comprobarIntegridadDeParametros(Usuario u)
        {
            if (u.Dni == null || u.Email == null || u.Apellido == null || u.Nombre == null || u.NombreDeUsuario == null)
            {
                throw new ArgumentNullException("parametros de usuario invalidos");
            }
            /*    if (u.Dni == "" || u.Email == "" || u.Apellido == "" || u.Nombre == "" || u.NombreDeUsuario == "")
                {
                    throw new ArgumentNullException("parametros de usuario invalidos");
                }*/
        }

        public Usuario(JObject usuarioJSON)
        {
            if (usuarioJSON["Domicilio"] == null)
            {
                this.Domicilio = "indefinido";
            }
            else
            {
                this.Domicilio = (string)usuarioJSON["Domicilio"];
            }

            try
            {
                this.NombreDeUsuario = (string)usuarioJSON["NombreDeUsuario"];
                this.Apellido = (string)usuarioJSON["Apellido"];
                this.Dni = (string)usuarioJSON["Dni"];
                this.Email = (string)usuarioJSON["Email"];
                this.Nombre = (string)usuarioJSON["Nombre"];
                this.SitCrediticia = (string)usuarioJSON["SitCrediticia"];
                this.Telefono = (string)usuarioJSON["Telefono"];
                this.Contraseña = (string)usuarioJSON["Contraseña"];
                //comprobarIntegridadDeParametros(this);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Usuario(List<string> ensamblador)
        {
            try
            {
                this.Dni = ensamblador[0];
                this.Nombre = ensamblador[1];
                this.Apellido = ensamblador[2];
                this.SitCrediticia = ensamblador[3];
                this.NombreDeUsuario = ensamblador[4];
                this.Domicilio = ensamblador[5];
                this.Email = ensamblador[6].ToLower();
                this.Telefono = ensamblador[7];
                //this.Contraseña = ensamblador[8]; //por seguridad, que la contraseña no este en memoria
                comprobarIntegridadDeParametros(this);
            }
            catch (Exception e)
            {
                Console.WriteLine("Parametros invalidos para ensamblar el Usuario --> " + e.Message);
                throw e;
            }
        }


        public static Usuario CrearUsuarioConNombreDeUsuario(string nombreDeUsuario)
        {
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

        public static Usuario ConsultarDatosPublicosUsuario(string nombre, string apellido, string email)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.Email = email;
            return usuario;
        }

        /*  public static Usuario nuevoUsuario(string dni, string nombre, string apellido, string nombreDeUsuario, string email, string telefono, string contraseña)
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

              try
              {
                  comprobarIntegridadDeParametros(usuarioNuevo);   
              }
              catch (Exception e)
              {
                  throw e;
              }

              return usuarioNuevo;
          }*/

    }
}