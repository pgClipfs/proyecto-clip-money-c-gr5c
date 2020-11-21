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
        public enum EstadoRegisto {REGISTRADO , ERROR , EXISTENTE}



        public Usuario consultar(Usuario t)
        {
            string script = "SELECT * FROM USUARIOS WHERE NOMBRE_USUARIO = " + "'" + t.NombreDeUsuario + "'";

            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

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
                    conexion.cerrar();
                    return new Usuario(ensamblador);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al ejecutar la consulta --> " + e.Message);
            }
            conexion.cerrar();
            return null;
        }


        public Enum registrar(Usuario t)
        {
            string script = "INSERT INTO USUARIOS (DNI, NOMBRE, APELLIDO, NOMBRE_SITUACION_CREDITICIA, NOMBRE_USUARIO, EMAIL, TELEFONO, CONTRASEÑA)" +
                "VALUES (@dni , @nombre , @apellido , @nombre_situacion_crediticia , @nombre_usuario , @email , @telefono , @contraseña)";

            /* Valido que el Usuario no exista previamente */

            if (consultar(t) != null) 
            {
                Console.WriteLine("El usuario ya existe en la BD");
                return EstadoRegisto.EXISTENTE;
            }

            /* Si el usuario no esta repetido, procedo a insertarlo en la BD */

            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            try
            {
                SqlCommand comando = new SqlCommand(script, conexion.conexionBD);
                comando.Parameters.AddWithValue("@dni", t.Dni);
                comando.Parameters.AddWithValue("@nombre", t.Nombre);
                comando.Parameters.AddWithValue("@apellido", t.Apellido);
                comando.Parameters.AddWithValue("@nombre_situacion_crediticia", t.SitCrediticia);
                comando.Parameters.AddWithValue("@nombre_usuario", t.NombreDeUsuario);
                comando.Parameters.AddWithValue("@email", t.Email);
                comando.Parameters.AddWithValue("@telefono", t.Telefono);
                comando.Parameters.AddWithValue("@contraseña", t.Contraseña);
                comando.ExecuteNonQuery();
                Console.WriteLine("Se realizo correctamente la inserción");
                conexion.cerrar();
                return EstadoRegisto.REGISTRADO;
            }
            catch (Exception e) 
            {
                Console.WriteLine("Error al realizar INSERT --> " + e.Message);
                conexion.cerrar();
                return EstadoRegisto.ERROR;
            }
        }

        public Enum eliminar(Usuario t)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> listarTodos()
        {
            throw new NotImplementedException();
        }

        public Enum modificar(Usuario t)
        {
            throw new NotImplementedException();
        }


    }
}