using System;
using System.Collections.Generic;

namespace ProyectoCLIPMoney
{
    public class Usuario
    {
        private int dni;
        private string nombre, apellido;
        private List<Cuenta> cuentas;
        private string sitCrediticia;

        public int DNI { get => dni;}
        public string Nombre { get => nombre;}
        public string Apellido { get => apellido;}
        public List<Cuenta> Cuentas { get => cuentas;}

        //queda en duda si situacion crediticia es propiedad de solo lectura o si se puede escribir
        public string SitCrediticia { get => sitCrediticia; set => sitCrediticia = value; }
                
        public Usuario(int DNI, string nombre, string apellido)
        {
            this.dni = DNI;
            this.nombre = nombre;
            this.apellido = apellido;
            //la situacion crediticia inicial siempre es la misma (falta definir cual sera esa situacion "inicial")
            //this.sitCrediticia = sitCrediticia;
            
            //parametros: divisa, tipo cuenta, usuario
            Cuenta cuenta = new Cuenta(null, null, this);
            cuentas.Add(cuenta);

            this.cuentas.Add(cuenta);            
        }
               
        public override string ToString()
        {
            return "Nombre: " + nombre + " Apellido: " + apellido + " DNI: " + dni + " Situación crediticia: " + sitCrediticia;
        }
    }
}
