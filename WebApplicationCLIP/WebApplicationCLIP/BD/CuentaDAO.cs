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
        public Cuenta consultar(Cuenta t)
        {
            string script = "SELECT * FROM CUENTAS WHERE CVU = " + "'" + t.Cvu + "'";

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
            return Cuenta.ensamblarCuenta(ensamblador, t);
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
            throw new NotImplementedException();
        }

        public void registrar(Cuenta t)
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