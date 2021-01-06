using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationCLIP.BD;
using WebApplicationCLIP.Models;

namespace WebApplicationCLIP.Gestores
{
    public class GestorUsuario
    {

        public bool consultarCredencialesUsuario(string nombreUsuario, string contraseña)
        {
            Usuario usu = Usuario.CrearUsuarioConNombreDeUsuario(nombreUsuario);
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            string temp;
            
            try
            {
                temp = usuarioDAO.consultarContraseñaUsuario(usu);
                return temp == contraseña;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


      /*  public void registrarUsuario(string dni, string nombre, string apellido, string nombreDeUsuario, string email, string telefono, string contraseña)
        {
            try
            {
                Usuario usuarioNuevo = Usuario.nuevoUsuario(dni, nombre, apellido, nombreDeUsuario, email, telefono, contraseña);
                UsuarioDAO usuarioDAO = new UsuarioDAO();
            }
            catch (Exception e)
            {
                throw e;
            }
        }*/

        public void registrarUsuario(Usuario usuarioNuevo)
        {
            try
            {
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                usuarioDAO.registrar(usuarioNuevo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Usuario consultarUsuarioPorDNI(string DNI)
        {
            Usuario temp = Usuario.CrearUsuarioConDNI(DNI);
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            try
            {
                Usuario usu = usuarioDAO.consultar(temp);
                return usu;

            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public static Usuario consultarUsuarioPorNombreDeUsuario(string nombre)
        {
            Usuario temp = Usuario.CrearUsuarioConNombreDeUsuario(nombre);
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            try
            {
                Usuario usu = usuarioDAO.consultar(temp); //aca da el problema
                return usu;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


    }
}