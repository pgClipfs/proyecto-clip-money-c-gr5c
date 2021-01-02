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
    [RoutePrefix("api")]
    public class DefaultController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("get/operaciones")]
        public IHttpActionResult GetOperacionesCuenta(JObject obj)
        {
            string cvu = (string)obj["Cvu"];
            SesionDeUsuario login = obj["SesionDeUsuario"].ToObject<SesionDeUsuario>();
            Cuenta cuenta;
            try
            {
                CuentaDAO cuentaDAO = new CuentaDAO();
                cuenta = cuentaDAO.consultar(cvu);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, "No se encontró una cuenta con ese CVU " + e.Message);
            }
            try
            {
                LoginController.ValidarSesion(login);
                Usuario usuario = GestorUsuario.consultarUsuarioPorNombreDeUsuario(login.NombreDeUsuario);

                if (!(cuenta.Usuario.NombreDeUsuario.ToString() == usuario.NombreDeUsuario.ToString()))
                {
                    return Content(HttpStatusCode.Forbidden, "Esta cuenta no pertenece al usuario correspondiente");
                }
            }
            catch (UnauthorizedAccessException e)
            {
                return Content(HttpStatusCode.Unauthorized, e.Message);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("sesion de usuario null");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
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
        [Route("get/datoscuenta")]
        public IHttpActionResult GetDatosCuenta(JObject obj)
        {
            string cvu = (string)obj["Cvu"];
            SesionDeUsuario login = obj["SesionDeUsuario"].ToObject<SesionDeUsuario>();
            Cuenta cuenta;
            try
            {
                CuentaDAO cuentaDAO = new CuentaDAO();
                cuenta = cuentaDAO.consultar(cvu);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, "No se encontró una cuenta con ese CVU " + e.Message);
            }
            try
            {
                LoginController.ValidarSesion(login);
                Usuario usuario = GestorUsuario.consultarUsuarioPorNombreDeUsuario(login.NombreDeUsuario);

                if (!(cuenta.Usuario.NombreDeUsuario.ToString() == usuario.NombreDeUsuario.ToString()))
                {
                    return Content(HttpStatusCode.Forbidden, "Esta cuenta no pertenece al usuario correspondiente");
                }
            }
            catch (UnauthorizedAccessException e)
            {
                return Content(HttpStatusCode.Unauthorized, e.Message);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("Sesion de usuario null " + e);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            try
            {
                GestorCuenta gestorCuenta = new GestorCuenta();
                Cuenta c = gestorCuenta.TraerCuenta(cvu);
                c.removerUsuario();
                return Ok(c);
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
        [Route("get/cuentasusuario")]
        public IHttpActionResult GetCuentasUsuario(SesionDeUsuario login)
        {
            try
            {
                LoginController.ValidarSesion(login);

                string nombreUsuario = login.NombreDeUsuario;
                Usuario usuario = Usuario.CrearUsuarioConNombreDeUsuario(nombreUsuario);
                UsuarioDAO usuarioDAO = new UsuarioDAO();
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
            Cuenta cuenta;
            try
            {
                CuentaDAO cuentaDAO = new CuentaDAO();
                cuenta = cuentaDAO.consultarCuenta(login);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, "No se encontró una cuenta con ese CVU " + e.Message);
            }
            try
            {
                LoginController.ValidarSesion(login);
                Usuario usuario = GestorUsuario.consultarUsuarioPorNombreDeUsuario(login.NombreDeUsuario);

                if (!(usuario.NombreDeUsuario.ToString() == usuario.NombreDeUsuario.ToString()))
                {
                    return Content(HttpStatusCode.Forbidden, "Esta cuenta no pertenece al usuario correspondiente");
                }
            }
            catch (UnauthorizedAccessException e)
            {
                return Content(HttpStatusCode.Unauthorized, e.Message);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("sesion de usuario null");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            try
            {
                GestorCuenta gestorCuenta = new GestorCuenta(); 
                return Ok(gestorCuenta.ObtenerCuentasDelUsuario(login));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("post/deposito")]
        public IHttpActionResult DepositarMonto(JObject obj)
        //public IHttpActionResult DepositarMonto(float monto, string cvu, [FromBody] SesionDeUsuario login)
        {
            float monto = (float)obj["Monto"];
            string cvu = (string)obj["Cvu"];
            SesionDeUsuario login = obj["SesionDeUsuario"].ToObject<SesionDeUsuario>();
            Cuenta cuenta;

            try
            {
                CuentaDAO cuentaDAO = new CuentaDAO();
                cuenta = cuentaDAO.consultar(cvu);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, "No se encontró una cuenta con ese CVU " + e.Message);
            }

            try
            {
                LoginController.ValidarSesion(login);
                Usuario usuario = GestorUsuario.consultarUsuarioPorNombreDeUsuario(login.NombreDeUsuario);

                if (!(cuenta.Usuario.NombreDeUsuario.ToString() == usuario.NombreDeUsuario.ToString()))
                {
                    return Content(HttpStatusCode.Forbidden, "Esta cuenta no pertenece al usuario correspondiente");
                }
            }
            catch (UnauthorizedAccessException e)
            {
                return Content(HttpStatusCode.Unauthorized, e.Message);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("sesion de usuario null");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }

            try
            {
                cuenta.Depositar(monto);
                //Operacion o = Operacion.crearOperacionExtraccion(null, monto);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, "No se pudó registrar la operación deposito " + e.Message);
            }
            //por ahora no se valida la sesion ni nada, simplemente se devuelven las operaciones del usuario
            //if (!LoginController.ValidarToken(sesion))return Unauthorized();
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("post/extraccion")]
        public IHttpActionResult ExtraerMonto(JObject obj)
        //public IHttpActionResult DepositarMonto(float monto, string cvu, [FromBody] SesionDeUsuario login)
        {
            float monto = (float)obj["Monto"];
            string cvu = (string)obj["Cvu"];
            SesionDeUsuario login = obj["SesionDeUsuario"].ToObject<SesionDeUsuario>();
            Cuenta cuenta;

            try
            {
                CuentaDAO cuentaDAO = new CuentaDAO();
                cuenta = cuentaDAO.consultar(cvu);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, "No se encontró una cuenta con ese CVU " + e.Message);
            }
            try
            {
                LoginController.ValidarSesion(login);
                Usuario usuario = GestorUsuario.consultarUsuarioPorNombreDeUsuario(login.NombreDeUsuario);

                if (!(cuenta.Usuario.NombreDeUsuario.ToString() == usuario.NombreDeUsuario.ToString()))
                {
                    return Content(HttpStatusCode.Forbidden, "Esta cuenta no pertenece al usuario correspondiente");
                }

            }
            catch (UnauthorizedAccessException e)
            {
                return Content(HttpStatusCode.Unauthorized, e.Message);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("sesion de usuario null");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }

            try
            {
                cuenta.Extraer(monto);
                //Operacion o = Operacion.crearOperacionExtraccion(null, monto);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, "No se pudó registrar la operación extracción " + e.Message);
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
        [Route("get/usuario")]
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