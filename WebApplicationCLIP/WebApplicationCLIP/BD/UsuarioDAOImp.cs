using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplicationCLIP.Models;

namespace WebApplicationCLIP.BD
{
    public class UsuarioDAOImp : UsuarioDAO
    {

        public Usuario consultar(Usuario t)
        {

            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            string script = "SELECT * FROM USUARIOS WHERE NOMBRE_USUARIO = " + "'" + t.NombreDeUsuario + "'";
            Usuario usuarioReturn = null;

            try 
            {
                SqlCommand comando = new SqlCommand(script, conexion.conexionBD);
                SqlDataReader lector = comando.ExecuteReader();
                List<string> ensamblador = new List<string>();
                while (lector.Read())
                {
                    for (int i = 0; i < lector.FieldCount; i++)
                    {
                        ensamblador.Add(lector.GetValue(i).ToString());
                    }
                }
                if (ensamblador.Count > 0)
                {
                    usuarioReturn = new Usuario(ensamblador);
                }
            }
            catch(Exception e)
            {

                Console.WriteLine("Error al ejecutar la consulta --> " + e.Message);
            }
            conexion.cerrar();
            return usuarioReturn;


        }

        public void eliminar(Usuario t)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> listarTodos()
        {
            throw new NotImplementedException();
        }

        public void modificar(Usuario t)
        {
            throw new NotImplementedException();
        }

        public void registrar(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}