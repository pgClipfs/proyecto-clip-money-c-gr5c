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

        public int consultar(Usuario t)
        {
            string script = "SELECT * FROM USUARIOS WHERE DNI = " + "'" + t.Dni + "'";

            if(t.Dni is null)
            {
                script = "SELECT * FROM USUARIOS WHERE NOMBRE_USUARIO = " + "'" + t.NombreDeUsuario + "'";
            }
            

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
                    Usuario.ensablarUsuario(ensamblador, t);
                    return 0;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error al ejecutar la consulta --> " + e.Message);
                //1: no se pudo conectar la BD
                return 1;
            }
            conexion.cerrar();
            return 1;
        }

        public int comprobarRepeticion(Usuario t)
        {
            string script = "SELECT * FROM USUARIOS WHERE NOMBRE_USUARIO = " + "'"  + t.NombreDeUsuario + "' or DNI ='"+t.Dni+"' or EMAIL = '"+t.Email+ "'";

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
                    
                    if(t.Dni == ensamblador[0])
                    {
                        return 3;
                    }
                    if(t.NombreDeUsuario == ensamblador[4])
                    {
                        return 4;
                    }
                    if (t.Email == ensamblador[5])
                    {
                        return 5;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al ejecutar la consulta --> " + e.Message);
                return 1;
            }
            conexion.cerrar();
            return 0;
        }

        public int registrar(Usuario t)
        {
            if (t.Dni == null || t.NombreDeUsuario==null ||t.Email==null)
            {
                return 6;
            }

            string script = "INSERT INTO USUARIOS (DNI, NOMBRE, APELLIDO, NOMBRE_SITUACION_CREDITICIA, NOMBRE_USUARIO, EMAIL, TELEFONO, CONTRASEÑA)" +
                "VALUES (@dni , @nombre , @apellido , @nombre_situacion_crediticia , @nombre_usuario , @email , @telefono , @contraseña)";

            /* Valido que el Usuario no exista previamente */

            int respuesta = comprobarRepeticion(t);

            if (respuesta !=0)
            {
                Console.WriteLine("Error tipo "+respuesta);
                return respuesta;
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
                return 0;
            }
            catch (Exception e) 
            {
                Console.WriteLine("Error al realizar INSERT --> " + e.Message);
                conexion.cerrar();
                return 2;
            }
        }

        public int eliminar(Usuario t)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> listarTodos()
        {
            throw new NotImplementedException();
        }

        public int modificar(Usuario t)
        {
            throw new NotImplementedException();
        }


    }
}