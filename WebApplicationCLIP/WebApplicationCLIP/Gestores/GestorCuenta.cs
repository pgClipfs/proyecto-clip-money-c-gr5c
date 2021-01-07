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
        public List<Cuenta> ObtenerCuentasDelUsuario(SesionDeUsuario login)
        {
            CuentaDAO cuentaDAO = new CuentaDAO();
            return cuentaDAO.consultarCuentasDelUsuario(login);
        }

        public void RegistrarCuenta(Cuenta cuenta)
        {
            CuentaDAO dao = new CuentaDAO();
            dao.registrar(cuenta);
        }
          

        public Cuenta TraerCuenta(string CVU)
        {
            Cuenta cuenta = Cuenta.crearCuentaConCVU(CVU);
            CuentaDAO cuentaDAO = new CuentaDAO();
            cuenta = cuentaDAO.consultar(CVU);
            return cuenta;
        }

        private string obtenerUltimoCVU()
        {
            CuentaDAO CuentaDAO = new CuentaDAO();
            return CuentaDAO.obtenerUltimoCVU();
        }

        public static void actualizar(Cuenta c)
        {
            CuentaDAO cuentaDAO = new CuentaDAO();
            cuentaDAO.modificar(c);
        }
    }
}