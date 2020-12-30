using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplicationCLIP.BD;
using WebApplicationCLIP.Gestores;
using WebApplicationCLIP.Models;

namespace WebApplicationCLIP.Controllers
{

    [AllowAnonymous]
    [RoutePrefix("api/get")]
    public class DefaultController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("operaciones")]
        public IHttpActionResult GetOperacionesCuenta(string cvu)
        {
            try
            {
                GestorOperacion gestorOperacion = new GestorOperacion();
                return Ok(gestorOperacion.ObtenerOperacionesPorCVU(cvu));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            //por ahora no se valida la sesion ni nada, simplemente se devuelven las operaciones del usuario
            //if (!LoginController.ValidarToken(sesion))return Unauthorized();
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("operaciones/deposito")]
        public IHttpActionResult DepositarMonto(string cvu, float monto)
        {
            try
            {
                GestorOperacion gestorOperacion = new GestorOperacion();
                if (gestorOperacion.depositar(cvu, monto))
                {
                    return Ok();
                }
                else
                {
                    return Content(HttpStatusCode.Conflict, "Error en el depósito");
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            //por ahora no se valida la sesion ni nada, simplemente se devuelven las operaciones del usuario
            //if (!LoginController.ValidarToken(sesion))return Unauthorized();
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("operaciones/extraccion")]
        public IHttpActionResult ExtraerMonto(string cvu, float monto)
        {
            try
            {
                GestorOperacion gestorOperacion = new GestorOperacion();
                if (gestorOperacion.extraer(cvu, monto))
                {
                    return Ok();
                }
                else
                {
                    return Content(HttpStatusCode.Conflict, "Error en la extracción");
                }
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            //por ahora no se valida la sesion ni nada, simplemente se devuelven las operaciones del usuario
            //if (!LoginController.ValidarToken(sesion))return Unauthorized();
        }

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("prueba")]
        public IHttpActionResult GetDatosUsuario()
        {
            //CuentaDAO cuenta = new CuentaDAO();

            Cuenta c = Cuenta.ObtenerCuenta();
            //int num = cuenta.consultar(c);
            return Ok(c);
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("usuario")]
        public IHttpActionResult GetDatosUsuario(SesionDeUsuario login)
        {
            try
            {
                LoginController.ValidarSesion(login);

                string nombreUsuario = login.NombreDeUsuario;
                Usuario usuario = Usuario.CrearUsuarioConNombreDeUsuario(nombreUsuario);
                UsuarioDAO usuarioDAO = new UsuarioDAO();

                return Ok(usuarioDAO.consultar(usuario));
            }
            catch (UnauthorizedAccessException e)
            {
                return Content(HttpStatusCode.Unauthorized, e.Message);
            }
            catch (HttpRequestException e)
            {
                return BadRequest();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }

        }

        private int ValidarCredencial(string nombreDeUsuario, object contraseña)
        {

            throw new NotImplementedException();
        }

        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}