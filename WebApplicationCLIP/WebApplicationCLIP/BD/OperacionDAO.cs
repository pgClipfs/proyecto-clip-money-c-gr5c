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

        public Operacion consultar(Cuenta t)
        {
            string script = "SELECT * FROM CUENTAS WHERE CVU = " + "'" + t.Cvu + "'";

            Operacion operacionResultado=null;

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
                        if (i == 1)
                        {
                            string dni = lector.GetValue(1).ToString();
                            i++;
                        }
                        ensamblador.Add(lector.GetValue(i).ToString());
                    }

                }
                if (ensamblador.Count > 0)
                {
                    conexion.cerrar();
                    t = Cuenta.ensamblarCuenta(ensamblador, t);

                    //aca hay que "ensamblar" el objeto operacion resultado
                    //operacionResultado = algo
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al ejecutar la consulta --> " + e.Message);
            }

            conexion.cerrar();
            return operacionResultado;
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

        public void registrar(Operacion t)
        {
            throw new NotImplementedException();
        }
    }
}