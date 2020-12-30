using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationCLIP.BD;
using WebApplicationCLIP.Models;

namespace WebApplicationCLIP.Gestores
{
    public class GestorOperacion
    {
        public List<Operacion> ObtenerOperacionesPorCVU(string cvu)
        {   
            OperacionDAO operacionDAO = new OperacionDAO();
            return operacionDAO.consultarOperacionesPorCVU(cvu);
        }
        public Operacion depositar(string cvu, float monto)
        {
            OperacionDAO operacionDAO = new OperacionDAO();
            return operacionDAO.depositar(cvu, monto);
        }
        public Operacion extraer(string cvu, float monto)
        {
             OperacionDAO operacionDAO = new OperacionDAO();
             return operacionDAO.extraer(cvu, monto);
        }
    }
}