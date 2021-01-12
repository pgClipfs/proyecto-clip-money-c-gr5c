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


        public Transferencia efectuarTransferencia(string cvuCuentaOrigen , string cvuCuentaDestino, Transferencia.CategoriaTransferencia categoria, string monto ) 
        {

            TransferenciaDAO transferenciaDAO = new TransferenciaDAO();
            Transferencia t = Transferencia.generarTransferencia(cvuCuentaOrigen, cvuCuentaDestino, categoria, monto);
            transferenciaDAO.efectuarTransferencia(t);


            // Retorna la Transferencia usada para registrar la BD , por si se quiere mostrar en el front-end los datos de la transferencia recien creada
            return t;



        }
    }
}