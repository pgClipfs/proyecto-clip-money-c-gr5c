using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebApplicationCLIP.Models;

namespace WebApplicationCLIP.BD
{
    public class ConexionBD
    {
        //aca pone el nombre de tu base de datos: 
        //Data Source= "nombre de tu conexion"
        //Initial Catalog= "nombre de tu base de datos"
        String cadena = "Data Source=localhost ;Initial Catalog=ClipBank;Integrated Security=True;";


        public SqlConnection conexionBD = new SqlConnection();

        public ConexionBD()
        {
            conexionBD.ConnectionString = cadena;
        }

        public List<List<string>> selectMultiple(string scriptSQL)
        {
            ConexionBD conexion = new ConexionBD();
            List<List<string>> ensamblador = new List<List<string>>();
            bool resultadoEncontrado = false;
            SqlCommand comando = new SqlCommand(scriptSQL, conexion.conexionBD);
            try
            {
                conexion.abrir();
                SqlDataReader lector = comando.ExecuteReader();
                int j = 0;
                while (lector.Read())
                {
                    ensamblador.Add(new List<string>());
                    resultadoEncontrado = true;
                    for (int i = 0; i < lector.FieldCount; i++)
                    {
                        ensamblador[j].Add(lector.GetValue(i).ToString());
                    }
                    j++;
                }

                if (!resultadoEncontrado)
                {
                    throw new ConsultaSinResultado();
                }
            }
            catch (ConsultaSinResultado e)
            {
                conexion.cerrar();
                throw e;
            }
            catch (Exception e)
            {
                conexion.cerrar();
                throw new Exception("Problema al ejecutar la consulta --->" + e.Message);
            }

            conexion.cerrar();
            return ensamblador;

        }

        public List<string> selectUnico(string scriptSQL)
        {
            ConexionBD conexion = new ConexionBD();
            List<string> ensamblador = new List<string>();
            bool resultadoEncontrado = false;
            SqlCommand comando = new SqlCommand(scriptSQL, conexion.conexionBD);
            try
            {
                conexion.abrir();
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    resultadoEncontrado = true;
                    for (int i = 0; i < lector.FieldCount; i++)
                    {
                        ensamblador.Add(lector.GetValue(i).ToString());
                    }
                }

                if (!resultadoEncontrado)
                {
                    throw new ConsultaSinResultado();
                }
            }
            catch (ConsultaSinResultado e)
            {
                conexion.cerrar();
                throw e;
            }
            catch (Exception e)
            {
                conexion.cerrar();
                throw new Exception("Problema al ejecutar la consulta --->" + e.Message);
            }

            conexion.cerrar();
            return ensamblador;

        }

        public void abrir()
        {
            try
            {
                conexionBD.Open();
                Console.WriteLine("Conexion abierta");
            }
            catch (Exception e)
            {
                throw new Exception("Error al abrir BD : " + e.Message);
            }
        }

        public void cerrar()
        {
            conexionBD.Close();
            Console.WriteLine("Conexion cerrada");
        }
    }
}