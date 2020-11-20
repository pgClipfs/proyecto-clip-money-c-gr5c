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

    }
}