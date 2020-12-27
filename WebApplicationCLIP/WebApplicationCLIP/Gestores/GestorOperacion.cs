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
    }
}