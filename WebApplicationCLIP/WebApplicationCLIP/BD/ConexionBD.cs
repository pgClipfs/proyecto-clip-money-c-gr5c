using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplicationCLIP.BD
{
    public class ConexionBD
    {
        //aca pone el nombre de tu base de datos: 
        //Data Source= "nombre de tu conexion"
        //Initial Catalog= "nombre de tu base de datos"
        //String cadena = "Data Source=localhost; Initial Catalog=ClipBD; Integrated Security=True";
        String cadena = "Data Source=DESKTOP-60F5ORQ\\SQLEXPRESS; Initial Catalog=ClipBank; Integrated Security=True";
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