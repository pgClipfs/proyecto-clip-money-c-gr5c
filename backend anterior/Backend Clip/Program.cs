using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Clip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio");

            Usuario usuario1 = new Usuario(41410969, "juan", "perez");

            Cuenta cuenta1 = usuario1.Cuentas[0];

            Console.WriteLine(cuenta1);



            Console.ReadLine();
        }
    }
}
