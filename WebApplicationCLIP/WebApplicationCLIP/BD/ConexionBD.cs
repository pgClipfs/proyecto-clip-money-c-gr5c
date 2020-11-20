using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplicationCLIP.BD
{
    public class ConexionBD
    {

        String cadena = "Data Source=localhost; Initial Catalog=ClipBD; Integrated Security=True";
        public SqlConnection conexionBD = new SqlConnection();

        public ConexionBD() 
        {
            conexionBD.ConnectionString = cadena;
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
                Console.WriteLine("Error al abrir BD : " + e.Message);
            }
        }

        public void cerrar() 
        {
            conexionBD.Close();
            Console.WriteLine("Conexion cerrada");
        }
    }
}