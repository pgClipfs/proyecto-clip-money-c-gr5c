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


        public bool efectuarTransferencia(string cvuCuentaOrigen , string cvuCuentaDestino, Transferencia.CategoriaTransferencia categoria, string monto ) 
        {

            TransferenciaDAO transferenciaDAO = new TransferenciaDAO();
            return transferenciaDAO.efectuarTransferencia(cvuCuentaOrigen, cvuCuentaDestino, categoria, monto);



        }
    }
}