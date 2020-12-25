using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationCLIP.Models;
using System.Data.SqlClient;

namespace WebApplicationCLIP.BD
{
    public class OperacionDAOImp : OperacionDAO
    {
        public int consultar(Cuenta t)
        {
            string script = "SELECT * FROM CUENTAS WHERE CVU = " + "'" + t.Cvu + "'";

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
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al ejecutar la consulta --> " + e.Message);
                //1: no se pudo conectar la BD
                return 1;
            }

            conexion.cerrar();
            return 1;
        }



        public int eliminar(Cuenta t)
        {
            throw new NotImplementedException();
        }

        public List<Cuenta> listarTodos()
        {
            throw new NotImplementedException();
        }

        public int modificar(Cuenta t)
        {
            throw new NotImplementedException();
        }

        public int registrar(Cuenta t)
        {
            throw new NotImplementedException(); //CONTINUAR AQUI
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