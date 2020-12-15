using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationCLIP.BD;
using WebApplicationCLIP.Models;
using System.Numerics;

namespace WebApplicationCLIP.Gestores
{
    public class GestorCuenta
    {

        public int crearCuenta(string DNI)
        {
            GestorUsuario gestorUsuario = new GestorUsuario();
            Usuario usuarioCuenta = gestorUsuario.consultarUsuarioPorDNI(DNI);
            string nuevoCVU = obtenerUltimoCVU();
            BigInteger temp = new BigInteger();
            BigInteger.TryParse(nuevoCVU, out temp);
            nuevoCVU = (temp + 1).ToString();
            Cuenta cuenta = new Cuenta(nuevoCVU, usuarioCuenta);

            return 0;
        }


        public int consultarCuenta(string CVU) 
        {
            Cuenta cuenta = Cuenta.crearCuentaConCVU(CVU);
            CuentaDAOImp cuentaDAO = new CuentaDAOImp();
            int respuesta = cuentaDAO.consultar(cuenta);
            return respuesta;
        }


        public Cuenta TraerCuenta(string CVU)
        {
            Cuenta cuenta = Cuenta.crearCuentaConCVU(CVU);
            CuentaDAOImp cuentaDAO = new CuentaDAOImp();
            cuentaDAO.consultar(cuenta);
            return cuenta;
        }



        private string obtenerUltimoCVU() 
        {
            CuentaDAOImp CuentaDAO = new CuentaDAOImp();
            return CuentaDAO.obtenerUltimoCVU();
        }

    }
}