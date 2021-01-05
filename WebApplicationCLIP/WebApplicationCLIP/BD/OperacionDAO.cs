using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCLIP.Models;

namespace WebApplicationCLIP.BD
{
    public class OperacionDAO : CRUD<Operacion>
    {
        public List<Operacion> consultarOperacionesPorCVU(string cvu)
        {
            string script = "SELECT * FROM OPERACIONES WHERE CVU = " + "'" + cvu + "' order by ID_OPERACION desc";
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

        public void registrar(Operacion o)
        {
            string cvu = o.Cuenta.Cvu;
            string registrarDeposito = "INSERT INTO OPERACIONES VALUES ('" + o.Monto + "', '" + o.Fecha.Date.ToString("yyyy-MM-dd") + "', '" + cvu + "', '" + o.TipoOperacion + "')";
            string idOperacion = "SELECT TOP 1 ID_OPERACION FROM OPERACIONES ORDER BY ID_OPERACION DESC";
            string montoCuenta = "SELECT SALDO FROM CUENTAS WHERE CVU = " + "'" + cvu + "'";
            float montoActual = 0;
            
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            string ultimoID = "";
            string temp = "";

            //Registro de operación deposito
            try
            {
                SqlCommand comando = new SqlCommand(registrarDeposito, conexion.conexionBD);
                comando.ExecuteNonQuery();

                SqlCommand comandoSaldo = new SqlCommand(montoCuenta, conexion.conexionBD);
                SqlDataReader lectorSaldo = comandoSaldo.ExecuteReader();
                while (lectorSaldo.Read())
                {
                  temp =  lectorSaldo.GetValue(0).ToString();
                }
                montoActual = float.Parse(temp);
                lectorSaldo.Close();

                SqlCommand comandoID = new SqlCommand(idOperacion, conexion.conexionBD);
                SqlDataReader lectorID = comandoID.ExecuteReader();
                while (lectorID.Read())
                {
                    ultimoID = lectorID.GetValue(0).ToString();
                }
                lectorID.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al registrar la operación depósito: " + e);
                throw e;
            }
            /*if (registroExitoso)
            {
                float resultado = montoActual + o.Monto;
                string depositar = "UPDATE CUENTAS SET SALDO = " + "'" + resultado.ToString() + "'" + " WHERE CVU = " + "'" + cvu + "'";
                try
                {   
                    SqlCommand comando = new SqlCommand(depositar, conexion.conexionBD);
                    comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string delete = "DELETE FROM OPERACIONES WHERE ID_OPERACION ="+ultimoID;
                    Console.WriteLine("Se revirtió el registro de la operación" + e);
                    conexion.cerrar(); 
                }
            }*/
            conexion.cerrar();
        }

        public Operacion consultar(string cvu)
        {
            return null;
        }

        public Operacion consultar(Operacion t)
        {
            throw new NotImplementedException();
        }

        public void eliminar(Operacion t)
        {
            throw new NotImplementedException();
        }

        public List<Operacion> listarTodos()
        {
            throw new NotImplementedException();
        }

        public void modificar(Operacion t)
        {
            throw new NotImplementedException();
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
    }
}