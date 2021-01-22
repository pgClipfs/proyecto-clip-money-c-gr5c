using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationCLIP.Models;
using WebApplicationCLIP.BD;

namespace WebApplicationCLIP.Gestores
{
    public class GestorTransferencia
    {
        public List<Transferencia> ObtenerTransferenciasPorCVU(string cvu, string tipoTransferencia)
        {
            /*OperacionDAO operacionDAO = new OperacionDAO();
            return operacionDAO.consultarTransferenciasPorCVU(cvu, tipoTransferencia);*/
            TransferenciaDAO transferenciaDAO = new TransferenciaDAO();
            List<Transferencia> transferencias=transferenciaDAO.consultarTransferencias(cvu);
            foreach (var transferencia in transferencias)
            {
                transferencia.BorrarDatosEscenciales();
            }

            return transferencias;
        }

    }
}