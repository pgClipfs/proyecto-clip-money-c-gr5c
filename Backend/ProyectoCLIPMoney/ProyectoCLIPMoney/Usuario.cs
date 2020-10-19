using System;
using System.Collections.Generic;
namespace ProyectoCLIPMoney
{
    public class Usuario
    {
        private int DNI;
        private string nombre, apellido, contraseña;
        private List<Cuenta> cuentas;
        private string sitCrediticia;

        //internal List<Cuenta> Cuentas { get => cuentas; set => cuentas = value; }

        public Usuario(int DNI, string nombre, string apellido, string contraseña, string sitCrediticia)
        {
            this.DNI = DNI;
            this.nombre = nombre;
            this.apellido = apellido;
            this.contraseña = contraseña;
            this.sitCrediticia = sitCrediticia;
            cuentas = new List<Cuenta>();
        }
        public static Usuario CrearUsuario(int DNI, string nombre, string apellido, string contraseña, string sitCrediticia)
        {
            Usuario usuario = new Usuario(DNI, nombre, apellido, contraseña, sitCrediticia);
            Random r = new Random();
            Cuenta cuenta = new Cuenta(r.Next(999999, 9999999), 0, "Pesos argentinos", null, usuario);
            usuario.AñadirCuenta(cuenta);
            return usuario;
        }
        public void AñadirCuenta(Cuenta c)
        {
            cuentas.Add(c);
        }
        public int GetDNI()
        {
            return DNI;
        }
        public string GetNombre()
        {
            return nombre;
        }
        public string GetApellido()
        {
            return apellido;
        }
        public Cuenta GetUnaCuentaAsociada(int indice)
        {
            return cuentas[indice];
        }
        public List<Cuenta> GetListaDeCuentas()
        {
            return cuentas;
        }

        public string GetSitCrediticia()
        {
            return sitCrediticia;
        }
        public void CambiarSitCrediticia(string nuevaSitCrediticia)
        {
            sitCrediticia = nuevaSitCrediticia;
        }
        public override string ToString()
        {
            return "Nombre: " + nombre + " Apellido: " + apellido + " DNI: " + DNI + " Situación crediticia: " + sitCrediticia;
        }
    }
}
