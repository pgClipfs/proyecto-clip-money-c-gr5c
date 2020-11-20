using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationCLIP.Controllers
{
    public class Prueba02Controller : ApiController
    {
        Usuario pepe = new Usuario("juan","perez");

        // GET: api/Prueba02
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Prueba02/5
        public Usuario Get(int id)
        {
            return pepe;
        }

        // POST: api/Prueba02
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Prueba02/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prueba02/5
        public void Delete(int id)
        {
        }

        public class Usuario
        {
            public Usuario(string nombre, string apellido)
            {
                Nombre = nombre;
                Apellido = apellido;
            }

            public string Nombre { get ; set; }
            public string Apellido { get ;set;}
        }
    }
}
