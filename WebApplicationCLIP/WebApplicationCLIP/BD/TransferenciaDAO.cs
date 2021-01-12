using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplicationCLIP.Models;

namespace WebApplicationCLIP.BD
{
    public class TransferenciaDAO : CRUD<Transferencia>
    {
        public Transferencia consultar(Transferencia t)
        {
            throw new NotImplementedException();
        }

        public void eliminar(Transferencia t)
        {
            throw new NotImplementedException();
        }

        public List<Transferencia> listarTodos()
        {
            throw new NotImplementedException();
        }

        public void modificar(Transferencia t)
        {
            throw new NotImplementedException();
        }

        public void registrar(Transferencia t)
        {
            // La Clase debe : Registrar los datos correspondientes a la operacion y a la transferencia en sus respectivas tablas y enlazarlas a traves del DATOS_OPERACION presente en transferencias


            string scriptOperacion = "INSERT INTO OPERACIONES ( MONTO , FECHA, CVU , NOMBRE_TIPO_OPERACION ) " + 
                "VALUES (@monto , @fecha , @cvu , @nombre_tipo_operacion)";


            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            try {
                SqlCommand comando = new SqlCommand(scriptOperacion, conexion.conexionBD);
                comando.Parameters.AddWithValue("@monto", t.Monto.ToString());
                comando.Parameters.AddWithValue("@fecha", t.Fecha.Date.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@cvu", t.Cuenta.Cvu);
                comando.Parameters.AddWithValue("@nombre_tipo_operacion", t.TipoOperacion.ToString());
                comando.ExecuteNonQuery();
                Console.WriteLine("Se realizo correctamente la inserción de la OPERACION");
                conexion.cerrar();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al realizar INSERT --> " + e.Message);
                conexion.cerrar();
                throw new Exception("Error al realizar INSERT --> " + e.Message);
            }


            // Transferencia


            string scriptTransferencia = "INSERT INTO TRANSFERENCIAS ( DATOS_OPERACION , NUMERO_TRANSFERENCIA , CVU_CUENTA_DESTINO , NOMBRE_CATEGORIA_TRANSFERENCIA , CONCEPTO ) " +
                "VALUES (@datos_operacion , @numero_transferencia , @cvu_cuenta_destino , @nombre_categoria_transferencia , @concepto)";

            try
            {
                conexion.abrir();
                SqlCommand comando = new SqlCommand(scriptTransferencia, conexion.conexionBD);
                comando.Parameters.AddWithValue("@datos_operacion", OperacionDAO.obtenerUltimaOperacionCreada());
                comando.Parameters.AddWithValue("@numero_transferencia", t.NumeroTransferencia);
                comando.Parameters.AddWithValue("@cvu_cuenta_destino", t.CuentaDestino.Cvu);
                comando.Parameters.AddWithValue("@nombre_categoria_transferencia", t.Categoria.ToString());
                comando.Parameters.AddWithValue("@concepto", "Esto es un concepto");
                comando.ExecuteNonQuery();
                Console.WriteLine("Se realizo correctamente la inserción de la TRANSFERENCIA");
                conexion.cerrar();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al realizar INSERT --> " + e.Message);
                conexion.cerrar();
                throw new Exception("Error al realizar INSERT --> " + e.Message);
            }
        }
    }
}