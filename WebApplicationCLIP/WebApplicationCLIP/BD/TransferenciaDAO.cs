using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplicationCLIP.Models;

namespace WebApplicationCLIP.BD
{
    public class TransferenciaDAO
    {
        public bool efectuarTransferencia(string cvuCuentaOrigen, string cvuCuentaDestino, Transferencia.CategoriaTransferencia categoria, string monto)
        {
            Transferencia t = Transferencia.generarTransferencia(cvuCuentaOrigen, cvuCuentaDestino, categoria, monto);

            string scriptOperacion = "INSERT INTO OPERACIONES (MONTO, FECHA, CVU, NOMBRE_TIPO_OPERACION) " +
                " VALUES (@monto , @fecha , @cvu , @nombre_tipo_operacion)";


            ConexionBD conexion = new ConexionBD();
            try
            {
                conexion.abrir();

                SqlCommand comando = new SqlCommand(scriptOperacion, conexion.conexionBD);
                comando.Parameters.AddWithValue("@monto", t.Monto);
                comando.Parameters.AddWithValue("@fecha", t.Fecha);
                comando.Parameters.AddWithValue("@cvu", t.Cuenta.Cvu);
                comando.Parameters.AddWithValue("@nombre_tipo_operacion", t.Categoria);
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

            // Obtenemos el numero de operacion
            Operacion operacion = Operacion.




            string scriptTransferencia = "INSERT INTO TRASFERENCIAS " ;






        }
    }
}