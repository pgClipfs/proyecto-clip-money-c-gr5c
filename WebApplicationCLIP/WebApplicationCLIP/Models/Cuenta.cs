﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using WebApplicationCLIP.Gestores;

namespace WebApplicationCLIP.Models
{
    public class Cuenta
    {
        public string Cvu { get; private set; }
        public Usuario Usuario { get; private set; }
        public float Saldo { get; private set; }
        public List<Operacion> Operaciones { get; private set; }
        public object Divisa { get; internal set; }
        public object TipoCuenta { get; internal set; }

        private Cuenta() { }
        
        public static Cuenta ObtenerCuenta()
        {
            Cuenta c = new Cuenta();
            
                c.Cvu = "12345";
            
            return c;
        }

        public Cuenta(string cvu, Usuario usuario)
        {
            if (cvu is null)
            {
                //excepcion de que uno de los argumentos es null
                throw new ArgumentNullException("cvu", "El cvu de una cuenta no puede ser null");
            }

            if (usuario is null)
            {
                //excepcion de que uno de los argumentos es null
                throw new ArgumentNullException("usuario", "El usuario de una cuenta no puede ser null");
            }

            this.Cvu = cvu;
            this.Usuario = usuario;
            this.Saldo = 0;
            this.Operaciones = new List<Operacion>();
        }

        public void Transferir(Cuenta cuentaDestino, float monto, string referencia, Transferencia.ConceptoTransferencia concepto)
        {
            //no se si tiene que devolver void

            Cuenta cuentaOrigen = this;

            if (monto > cuentaOrigen.Saldo || monto <= 0)
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
            if (monto <= 0)
            {
                throw new Exception("No se puede depositar un monto negativo o igual a 0.");
            }
            Saldo += monto;
            Operacion o = Operacion.crearOperacionDeposito(this, monto);
            GestorOperacion gestorOperacion = new GestorOperacion();
            GestorCuenta.actualizar(this);
            gestorOperacion.registrar(o);
        }

        public void Extraer(float monto)
        {
            if (monto <= 0)
            {
                throw new Exception("No se puede extraer un monto negativo o igual a 0.");
            }
            if (Saldo < monto)
            {
                throw new Exception("El saldo a extraer es mayor al disponible en la cuenta.");
            }
            Saldo -= monto;
            Operacion o = Operacion.crearOperacionExtraccion(this, monto);
            GestorOperacion gestorOperacion = new GestorOperacion();
            GestorCuenta.actualizar(this);
            gestorOperacion.registrar(o);
        }

        public static Cuenta ensamblarCuenta(List<string> ensamblador)
        {
            Cuenta c = new Cuenta();
            return ensamblarCuenta(ensamblador, c);

        }

        public static Cuenta ensamblarCuenta(List<string> ensamblador, Cuenta cuenta)
        {
            cuenta.Cvu = ensamblador[0];
            cuenta.Usuario = GestorUsuario.consultarUsuarioPorDNI(ensamblador[1]);
            cuenta.Saldo = float.Parse(ensamblador[2]);
            // Todavia no se programo la obtencion de las operaciones
            cuenta.Operaciones = null;
            return cuenta;
        }

        public void removerUsuario()
        {
            Usuario = null;
        }

        public static Cuenta crearCuentaConDNI(string DNI)
        {
            Cuenta cuenta = new Cuenta();
            cuenta.Usuario = GestorUsuario.consultarUsuarioPorDNI(DNI);
            return cuenta;
        }
        
        public static Cuenta crearCuentaConCVU(string CVU)
        {
            Cuenta cuenta = new Cuenta();
            cuenta.Cvu = CVU;
            return cuenta;
        }

    }
}