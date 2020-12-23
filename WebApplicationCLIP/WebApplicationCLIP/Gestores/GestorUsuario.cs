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
        /* Aqui deberia devolver un tipo de dato que muestre el estado de lo que sucede y no "bool"   */

            /*
             codigos de error:

            0: sin error
            1: error conexion a BD
            2: error en credenciales
             
             */

        public int consultarCredencialesUsuario(string nombreUsuario, string contraseña)
        {
            Usuario temp = Usuario.CrearUsuarioConNombreDeUsuario(nombreUsuario);
            UsuarioDAOImp usuarioDAO = new UsuarioDAOImp();
            int respuesta = usuarioDAO.consultar(temp);

            if ( respuesta !=0)
            {
                return respuesta;
            }

            if (temp.Contraseña != contraseña)
            {
                Console.WriteLine("Contraseña invalida para el usuario '" + temp.NombreDeUsuario + "'");
                return 2;
            }
            return 0;
        }


        public int registrarUsuario(string dni, string nombre, string apellido, string nombreDeUsuario, string email, string telefono, string contraseña) 
        {
            Usuario usuarioNuevo = Usuario.nuevoUsuario(dni, nombre, apellido, nombreDeUsuario, email, telefono, contraseña);
            UsuarioDAOImp usuarioDAO = new UsuarioDAOImp();
            return usuarioDAO.registrar(usuarioNuevo);
        }

        public int registrarUsuario(Usuario usuarioNuevo)
        {
            UsuarioDAOImp usuarioDAO = new UsuarioDAOImp();
            return usuarioDAO.registrar(usuarioNuevo);
        }


        public Usuario consultarUsuarioPorDNI(string DNI) 
        {
            Usuario temp = Usuario.CrearUsuarioConDNI(DNI);
            UsuarioDAOImp usuarioDAO = new UsuarioDAOImp();
            int respuesta = usuarioDAO.consultar(temp);

            return temp;

        }


    }
}