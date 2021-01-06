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
            List<Cuenta> cuentas = null;
            List<List<string>> ensamblador = new List<List<string>>();

            try
            {
                ConexionBD conexionBD = new ConexionBD();
                ensamblador = conexionBD.selectMultiple(script);
            }
            catch (ConsultaSinResultado e)
            {
                throw new Exception("El usuario no tiene Cuentas");
            }
            
            cuentas = new List<Cuenta>();
            for (int i = 0; i < ensamblador.Count; i++)
            {
                cuentas.Add(Cuenta.ensamblarCuenta(ensamblador[i]));
            }
            
            foreach (var item in cuentas)
            {
                item.removerUsuario();
            }

            return cuentas;
        }

        public Cuenta consultar(string cvu)
        {
            string script = "SELECT * FROM CUENTAS WHERE CVU = " + "'" + cvu + "'";
            List<string> ensamblador;

            try
            {
                ConexionBD conexionBD = new ConexionBD();
                ensamblador = conexionBD.selectUnico(script);
            }
            catch (ConsultaSinResultado e)
            {
                throw new CvuInvalido();
            }

            return Cuenta.ensamblarCuenta(ensamblador);

        }

        public List<Operacion> consultarOperacionesPorCVU(string cvu)
        {
            string script = "SELECT * FROM OPERACIONES WHERE CVU = " + "'" + cvu + "'";
            List<Operacion> operaciones = null;
            List<List<string>> ensamblador = new List<List<string>>();

            try
            {
                ConexionBD conexionBD = new ConexionBD();
                ensamblador = conexionBD.selectMultiple(script);
            }
            catch (ConsultaSinResultado e)
            {
                throw new Exception("La cuenta no tiene operaciones");
            }

            if (ensamblador.Count > 0)
            {
                operaciones = new List<Operacion>();
                for (int i = 0; i < ensamblador.Count; i++)
                {
                    operaciones.Add(Operacion.ensamblarOperacion(ensamblador[i]));
                }
            }

            return operaciones;
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