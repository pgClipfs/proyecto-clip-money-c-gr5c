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

        public bool consultarCredencialesUsuario(string nombreUsuario, string contraseña)
        {
            Usuario temp = new Usuario(nombreUsuario);
            UsuarioDAOImp usuarioDAO = new UsuarioDAOImp();
            Usuario usuario = usuarioDAO.consultar(temp);

            if (usuario == null)
            {
                Console.WriteLine("No se encontro el usuario '" + nombreUsuario + "'");
                return false;
            }
            if (usuario.Contraseña != contraseña)
            {
                Console.WriteLine("Contraseña invalida para el usuario '" + usuario.NombreDeUsuario + "'");
                return false;
            }
            return true;
        }


        /*El metodo registra un usuario (verificando que este no sea repetido)
         * y devuelve un Enum con 3 Estados : REGISTRADO - ERROR - EXISTENTE  */

        /* Para obtener el valor de un Enum se utiliza el metodo  --> ToString() <--   */
        public Enum registrarUsuario(string dni, string nombre, string apellido, string nombreDeUsuario, string email, string telefono, string contraseña) 
        {
            Usuario usuarioNuevo = Usuario.nuevoUsuario(dni, nombre, apellido, nombreDeUsuario, email, telefono, contraseña);
            UsuarioDAOImp usuarioDAO = new UsuarioDAOImp();
            return usuarioDAO.registrar(usuarioNuevo);
        }

    }
}