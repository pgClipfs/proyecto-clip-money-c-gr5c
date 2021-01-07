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

        public string consultarContraseñaUsuario(Usuario t)
        {
            string script = "SELECT * FROM USUARIOS WHERE NOMBRE_USUARIO = " + "'" + t.NombreDeUsuario + "'";
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            List<string> ensamblador = new List<string>();
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
                if (ensamblador.Count > 0)
                {
                    conexion.cerrar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            conexion.cerrar();
            return ensamblador[8];

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
                        throw new ErrorDniRepetido(ensamblador[0]);
                    }
                    if (t.NombreDeUsuario == ensamblador[4])
                    {
                        throw new ErrorNombreUsuarioRepetido(t.NombreDeUsuario);
                    }
                    if (t.Email == ensamblador[6])
                    {
                        throw new ErrorEmailRepetido(t.Email);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            conexion.cerrar();
        }

        public void registrar(Usuario t)
        {
            if (t.Dni == null || t.NombreDeUsuario == null || t.Email == null)
            {
                throw new Exception("Faltan datos para poder registrar al usuario");
            }

            string script = "INSERT INTO USUARIOS (DNI, NOMBRE, APELLIDO, NOMBRE_SITUACION_CREDITICIA, NOMBRE_USUARIO, DOMICILIO, EMAIL, TELEFONO, CONTRASEÑA)" +
                "VALUES (@dni , @nombre , @apellido , @nombre_situacion_crediticia , @nombre_usuario , @domicilio , @email , @telefono , @contraseña)";

            /* Valido que el Usuario no exista previamente */

            comprobarRepeticion(t);


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
                comando.Parameters.AddWithValue("@domicilio", t.Domicilio);
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

        public void modificarDatosUsuario(string domi, string email, string tel, SesionDeUsuario login)
        {
            //se guardan los datos actuales en caso de no llegar a cambiar alguno
            string scriptDomi = "SELECT DOMICILIO FROM USUARIOS WHERE NOMBRE_USUARIO = '" + login.NombreDeUsuario + "' ";
            string scriptEmail = "SELECT EMAIL FROM USUARIOS WHERE NOMBRE_USUARIO = '" + login.NombreDeUsuario + "' ";
            string scriptTel = "SELECT TELEFONO FROM USUARIOS WHERE NOMBRE_USUARIO = '" + login.NombreDeUsuario + "' ";
            string domicilioActual = "";
            string emailActual = "";
            string telActual = "";
            try
            {
                ConexionBD conexionBD = new ConexionBD();
                conexionBD.abrir();

                SqlCommand comandoDomicilio = new SqlCommand(scriptDomi, conexionBD.conexionBD);
                SqlDataReader lectorDomicilio = comandoDomicilio.ExecuteReader();

                while (lectorDomicilio.Read())
                {
                    domicilioActual = lectorDomicilio.GetValue(0).ToString();
                }
                lectorDomicilio.Close();

                SqlCommand comandoEmail = new SqlCommand(scriptEmail, conexionBD.conexionBD);
                SqlDataReader lectorEmail = comandoEmail.ExecuteReader();

                while (lectorEmail.Read())
                {
                    emailActual = lectorEmail.GetValue(0).ToString();
                }
                lectorEmail.Close();

                SqlCommand comandoTel = new SqlCommand(scriptTel, conexionBD.conexionBD);
                SqlDataReader lectorTel = comandoTel.ExecuteReader();

                while (lectorTel.Read())
                {
                    telActual = lectorTel.GetValue(0).ToString();
                }
                lectorTel.Close();

                conexionBD.cerrar();
            }
            catch (Exception e)
            {
                throw e;
            }

            string selectEmails = "SELECT EMAIL FROM USUARIOS";
            string selectTel = "SELECT TELEFONO FROM USUARIOS";

            List<string> emails;
            List<string> telefonos;

            try
            {
                ConexionBD conexionBD = new ConexionBD();
                conexionBD.abrir();

                emails = conexionBD.selectUnico(selectEmails);
                telefonos = conexionBD.selectUnico(selectTel);

                //Se comprueba que el email o telefono a modificar no exista en la BD, caso contrario se lanza excepción
                if (emails.Contains(email))
                {
                    throw new ErrorEmailRepetido("Este email ya está registrado.");
                }
                if (telefonos.Contains(tel))
                {
                    throw new ErrorTelefonoRepetido("Este teléfono ya está registrado.");
                }

                if (domi.Trim() == "")
                {
                    domi = domicilioActual;
                }
                if (email.Trim() == "")
                {
                    email = emailActual;
                }
                if (tel.Trim() == "")
                {
                    tel = telActual;
                }
                conexionBD.cerrar();
            }
            catch (ErrorEmailRepetido e)
            {
                throw e;
            }
            catch (ErrorTelefonoRepetido e)
            {
                throw e;
            }

            //Recién acá se empezaría a efectuar la parte donde se actualizan los datos del usuario

            string actualizar = "UPDATE USUARIOS SET DOMICILIO = '" + domi + "', EMAIL = '" + email + "', TELEFONO = " +
                "'" + tel + "' WHERE NOMBRE_USUARIO = '" + login.NombreDeUsuario + "'";

            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            try
            {
                SqlCommand comando = new SqlCommand(actualizar, conexion.conexionBD);
                SqlDataReader lector = comando.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception("Se produjo un error al modificar los datos --> " + e.Message);
            }
            conexion.cerrar();
        }

        public void eliminar(Usuario t)
        {
            throw new NotImplementedException();
        }
    }
}
