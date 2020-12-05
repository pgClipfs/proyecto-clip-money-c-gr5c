﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace WebApplicationCLIP.Models
{
    public class Cuenta
    {        
        public string Cvu { get ; private set ; }
        public Usuario Usuario { get; private set; }
        public float Saldo { get; private set; }
        public List<Operacion> Operaciones { get; private set; }

        public Cuenta(string cvu, Usuario usuario)
        {
            this.Cvu = cvu;
            this.Usuario = usuario;
            this.Saldo = 0;
            this.Operaciones = new List<Operacion>();
        }

        public void Transferir(Cuenta cuentaDestino, float monto, string referencia, Transferencia.ConceptoTransferencia concepto)
        {
            //no se si tiene que devolver void

            Cuenta cuentaOrigen = this;

            if (monto>this.Saldo || monto<=0)
            {
                //no se puede hacer la operacion                
                return;//se podria usar una excepcion personalizada
            }

            Transferencia transferencia = new Transferencia(cuentaDestino, cuentaOrigen, monto, referencia, concepto);
            cuentaDestino.RegistrarTransferencia(transferencia);
            cuentaOrigen.RegistrarTransferencia(transferencia);

            //comandos para guardar todo en la BD (la transferencia solo se debe guardar una unica vez)

        }

        private void RegistrarTransferencia(Transferencia transferencia)
        {
            if (this == transferencia.Cuenta)
            {
                //si esta cuenta es la que envio la transferencia
                this.Saldo -= transferencia.Monto;
                //comandos para registrar la operacion como transferencia recibida
            }
            else
            {
                if (this == transferencia.CuentaDestino)
                {
                    //si esta cuenta es la que esta recibiendo la transferencia
                    Saldo += transferencia.Monto;
                    //comandos para registrar la operacion como transferencia recibida
                }
            }

            Operaciones.Add(transferencia);

            //comandos para generar operacion y agregarla a la lista
        }

        public void Depositar(float monto)
        {
            //no se si tiene que devolver void
        }

        public void Extraer(float monto)
        {
            //no se si tiene que devolver void
        }
    }
}