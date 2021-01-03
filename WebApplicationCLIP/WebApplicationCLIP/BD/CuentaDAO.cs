using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationCLIP.Models;
using System.Data.SqlClient;

namespace WebApplicationCLIP.BD
{
    public class CuentaDAO : CRUD<Cuenta>
    {
        public List<Cuenta> consultarCuentasDelUsuario(SesionDeUsuario login)
        {
            string script = "select CVU, DNI_USUARIO, SALDO, DIVISA, TIPO_CUENTA from CUENTAS c inner join Usuarios u on c.DNI_USUARIO = u.DNI where NOMBRE_USUARIO = " + "'" + login.NombreDeUsuario + "'";
            List<Cuenta> temp = null;
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            try
            {
                SqlCommand comando = new SqlCommand(script, conexion.conexionBD);
                SqlDataReader lector = comando.ExecuteReader();
                List<List<string>> cuentas = new List<List<string>>();
                int j = 0;
                while (lector.Read())
                {
                    cuentas.Add(new List<string>());
                    for (int i = 0; i < lector.FieldCount; i++)
                    {
                        cuentas[j].Add(lector.GetValue(i).ToString());
                    }
                    j++;

                }
                if (cuentas.Count > 0)
                {
                    temp = new List<Cuenta>();
                    for (int i = 0; i < cuentas.Count; i++)
                    {
                        temp.Add(Cuenta.ensamblarCuenta(cuentas[i]));
                    }
                    conexion.cerrar();

                    //aca hay que "ensamblar" el objeto operacion resultado
                    //operacionResultado = algo
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al ejecutar la consulta --> " + e.Message);
            }

            conexion.cerrar();

            foreach (var item in temp)
            {
                item.removerUsuario();
            }

            return temp;
        }

        public Cuenta consultarCuenta(SesionDeUsuario login)
        {
            return null;
        }

        public Cuenta consultar(string cvu)
        {
            string script = "SELECT * FROM CUENTAS WHERE CVU = " + "'" + cvu + "'";

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
                throw new Exception("Error al ejecutar la consulta --> " + e.Message);
            }
            conexion.cerrar();
            return Cuenta.ensamblarCuenta(ensamblador);
            
        }

        public List<Operacion> consultarOperacionesPorCVU(string cvu)
        {
            string script = "SELECT * FROM OPERACIONES WHERE CVU = " + "'" + cvu + "'";
            List<Operacion> temp = null;
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            try
            {
                SqlCommand comando = new SqlCommand(script, conexion.conexionBD);
                SqlDataReader lector = comando.ExecuteReader();
                List<List<string>> operaciones = new List<List<string>>();
                int j = 0;
                while (lector.Read())
                {
                    operaciones.Add(new List<string>());
                    for (int i = 0; i < lector.FieldCount; i++)
                    {
                        operaciones[j].Add(lector.GetValue(i).ToString());
                    }
                    j++;

                }
                if (operaciones.Count > 0)
                {
                    temp = new List<Operacion>();
                    for (int i = 0; i < operaciones.Count; i++)
                    {
                        temp.Add(Operacion.ensamblarOperacion(operaciones[i]));
                    }
                    conexion.cerrar();

                    //aca hay que "ensamblar" el objeto operacion resultado
                    //operacionResultado = algo
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al ejecutar la consulta --> " + e.Message);
            }

            conexion.cerrar();

            return temp;
        }

        public void eliminar(Cuenta t)
        {
            throw new NotImplementedException();
        }

        public List<Cuenta> listarTodos()
        {
            throw new NotImplementedException();
        }

        public void modificar(Cuenta t)
        {
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();
            string actualizar = "UPDATE CUENTAS SET SALDO = " + "'" + t.Saldo.ToString() + "'" + " WHERE CVU = " + "'" + t.Cvu + "'";
            try
            {
                SqlCommand comando = new SqlCommand(actualizar, conexion.conexionBD);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            conexion.cerrar();
        }

        public void registrarCuentaHarcodeada(Cuenta t)
        {

            string script = "INSERT INTO CUENTAS VALUES ('" + "0001111" + "', '" + "41225476" + "', " +
                "'" + "2000" + "', '" + " Pesos " + "', '" + "Cuenta de ahorro" + "')";

            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            try
            {
                SqlCommand comando = new SqlCommand(script, conexion.conexionBD);
                SqlDataReader lector = comando.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception("Error al ejecutar la consulta --> " + e.Message);
            }
            conexion.cerrar();
            return;

        }
        public void registrar(Cuenta t)
        {

            //string script = "INSERT INTO CUENTAS (CVU, DNI_USUARIO, SALDO, DIVISA, TIPO_CUENTA) values" +
              // (t.Cvu, t.DNI_USUARIO, t.Saldo, t.DIVISA, t.TIPO_CUENTA.ToString());
            string script = "INSERT INTO CUENTAS VALUES ('" + t.Cvu + "', '" + t.Usuario.Dni + "', " +
                "'" + t.Saldo + "', '" + t.Divisa + "', '" + t.TipoCuenta + "')";

            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            try
            {
                SqlCommand comando = new SqlCommand(script, conexion.conexionBD);
                SqlDataReader lector = comando.ExecuteReader();
            }
            catch (Exception e)
            {
                throw new Exception("Error al ejecutar la consulta --> " + e.Message);
            }
            conexion.cerrar();
            return;

        }

        public string obtenerUltimoCVU()
        {
            string script = "SELECT TOP 1 * FROM CUENTAS ORDER BY CVU DESC";
            string ultimoCVU;

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
                    ultimoCVU = ensamblador[0];
                    return ultimoCVU;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al ejecutar la consulta --> " + e.Message);
            }
            conexion.cerrar();
            return "ERROR";
        }

        public Cuenta consultar(Cuenta t)
        {
            throw new Exception();
        }
    }
}