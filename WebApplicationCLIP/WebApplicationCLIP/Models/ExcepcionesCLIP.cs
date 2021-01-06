using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationCLIP.Models
{

    public class CvuInvalido : Exception
    {
        public CvuInvalido()
             : base("No existe una cuenta con ese CVU") { }
    }

    public class ErrorDniRepetido : Exception
    {
        public ErrorDniRepetido(string dni)
            : base("Dni Repetido: " + dni) { }
    }
    public class ErrorEmailRepetido : Exception
    {
        public ErrorEmailRepetido(string email)
            : base("Email Repetido: " + email) { }
    }

    public class ErrorNombreUsuarioRepetido : Exception
    {
        public ErrorNombreUsuarioRepetido(string nombre)
            : base("Nombre de Usuario Repetido: " + nombre) { }
    }

    public class SesionExpirada : Exception
    {
        public SesionExpirada()
            : base("La sesión del usuario expiró") { }
    }

    public class UsuarioNoEncontrado : Exception
    {
        public UsuarioNoEncontrado(string usu)
            : base("No se encontro el usuario " + usu) { }
    }

    public class SaldoInsuficiente : Exception
    {
        public SaldoInsuficiente()
            : base("Saldo insuficiente para realizar la operacion") { }
        public SaldoInsuficiente(string msg)
            : base(msg) { }
    }

    public class MontoInvalido : Exception
    {
        public MontoInvalido()
            : base("El monto no puede ser negativo, y debe ser mayor a cero") { }
        public MontoInvalido(string msg)
            : base(msg) { }
    }

    public class ErrorTransferencia : Exception
    {
        public ErrorTransferencia(string msg)
            : base("Error al realizar la transferencia: " + msg) { }
    }
}