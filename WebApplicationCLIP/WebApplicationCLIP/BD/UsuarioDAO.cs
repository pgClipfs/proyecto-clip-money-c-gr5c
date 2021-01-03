using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http;
using WebApplicationCLIP.Models;

namespace WebApplicationCLIP.BD
{
    public class UsuarioDAO : CRUD<Usuario>
    {
        public Usuario consultarDNI(Usuario t)
        {
            string script = "SELECT DNI FROM USUARIOS WHERE DNI = " + "'" + t.Dni + "'";
            if (t.Dni is null)
            {
                script = "SELECT * FROM USUARIOS WHERE NOMBRE_USUARIO = " + "'" + t.NombreDeUsuario + "'";
            }

            ConexionBD conexion = new ConexionBD();
            conexion.abrir();
            List<string> ensamblador = new List<string>();
            Usuario usuario_resultado;

            try
            {
                SqlCommand comando = new SqlCommand(script, conexion.conexionBD);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    for (int i = 0; i < lector.FieldCount; i++)
                    {
                        ensamblador.Add(lector.GetValue(i).ToString());
                    }
                }
                usuario_resultado = new Usuario(ensamblador);
            }
            catch (Exception e)
            {
                throw new Exception("Error al ejecutar la consulta --> " + e.Message);
            }
            conexion.cerrar();
            return usuario_resultado;
        }
        public Usuario consultarConCvu(string cvu)
        {
            string script = "SELECT * FROM CUENTAS WHERE DNI = " + "'" + cvu + "'";

            if (cvu is null)
            {
                throw new ArgumentNullException("El CVU es null");
            }

            ConexionBD conexion = new ConexionBD();
            conexion.abrir();
            List<string> ensamblador = new List<string>();
            Usuario usuario_resultado;

            try
            {
                SqlCommand comando = new SqlCommand(script, conexion.conexionBD);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    for (int i = 0; i < lector.FieldCount; i++)
                    {
                        ensamblador.Add(lector.GetValue(i).ToString());
                    }
                }
                usuario_resultado = new Usuario(ensamblador);
            }
            catch (Exception e)
            {
                throw new Exception("Error al ejecutar la consulta --> " + e.Message);
            }
            conexion.cerrar();
            return usuario_resultado;
        }
        public Usuario consultar(Usuario t)
        {
            string script = "SELECT * FROM USUARIOS WHERE DNI = " + "'" + t.Dni + "'";

            if (t.Dni is null)
            {
                script = "SELECT * FROM USUARIOS WHERE NOMBRE_USUARIO = " + "'" + t.NombreDeUsuario + "'";
            }

            ConexionBD conexion = new ConexionBD();
            conexion.abrir();
            List<string> ensamblador = new List<string>();
            Usuario usuario_resultado;

            try
            {
                SqlCommand comando = new SqlCommand(script, conexion.conexionBD);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    for (int i = 0; i < lector.FieldCount; i++)
                    {
                        ensamblador.Add(lector.GetValue(i).ToString());
                    }
                }
                usuario_resultado = new Usuario(ensamblador);
            }
            catch (Exception e)
            {
                throw new Exception("Error al ejecutar la consulta --> " + e.Message);
            }
            conexion.cerrar();
            return usuario_resultado;
        }

        public void comprobarRepeticion(Usuario t)
        {
            string script = "SELECT * FROM USUARIOS WHERE NOMBRE_USUARIO = " + "'" + t.NombreDeUsuario + "' or DNI ='" + t.Dni + "' or EMAIL = '" + t.Email + "'";
            
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

                    if (t.Dni == ensamblador[0])
                    {
                        throw new Exception("Dni repetido");
                    }
                    if (t.NombreDeUsuario == ensamblador[4])
                    {
                        throw new Exception("Nombre de usuario repetido");
                    }
                    if (t.Email == ensamblador[5])
                    {
                        throw new Exception("Email repetido");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al ejecutar la consulta --> " + e.Message);
            }
            conexion.cerrar();
        }

        public void registrar(Usuario t)
        {
            if (t.Dni == null || t.NombreDeUsuario == null || t.Email == null)
            {
                throw new Exception("Faltan datos para poder registrar al usuario");
            }

            string script = "INSERT INTO USUARIOS (DNI, NOMBRE, APELLIDO, NOMBRE_SITUACION_CREDITICIA, NOMBRE_USUARIO, EMAIL, TELEFONO, CONTRASEÑA)" +
                "VALUES (@dni , @nombre , @apellido , @nombre_situacion_crediticia , @nombre_usuario , @email , @telefono , @contraseña)";

            /* Valido que el Usuario no exista previamente */

            try
            {
                comprobarRepeticion(t);
            }
            catch (Exception e)
            {
                throw e;
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
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al realizar INSERT --> " + e.Message);
                conexion.cerrar();
                throw new Exception("Error al realizar INSERT --> " + e.Message);
            }
        }

        public List<Usuario> listarTodos()
        {
            throw new NotImplementedException();
        }

        public void modificar(Usuario t)
        {
            throw new NotImplementedException();
        }

        public void eliminar(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}