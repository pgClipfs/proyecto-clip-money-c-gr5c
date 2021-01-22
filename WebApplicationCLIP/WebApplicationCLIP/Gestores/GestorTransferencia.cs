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
      
        public List<Transferencia> consultarTransferencia(string cvu) 
        {

            TransferenciaDAO dao = new TransferenciaDAO();
            List<Transferencia> transferencias = dao.consultarTransferencias(cvu);
            return transferencias;

        }
    }
}