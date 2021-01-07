using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class OperacionesController : ApiController
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
                return Content(HttpStatusCode.ExpectationFailed, "No se encontró una cuenta con ese CVU --> " + e.Message);
            }
            try
            {
                LoginController.ValidarSesion(login);
                Usuario usuario = GestorUsuario.consultarUsuarioPorNombreDeUsuario(login.NombreDeUsuario);

                if (!(cuenta.Usuario.NombreDeUsuario.ToString() == usuario.NombreDeUsuario.ToString()))
                {
                    return Content(HttpStatusCode.Forbidden, "Esta cuenta no pertenece al usuario correspondiente.");
                }
            }
            catch (UnauthorizedAccessException e)
            {
                return Content(HttpStatusCode.Unauthorized, e.Message);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("Sesion de usuario null --> " + e);
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
                return Content(HttpStatusCode.ExpectationFailed, "No se encontró una cuenta con ese CVU --> " + e.Message);
            }

            try
            {
                LoginController.ValidarSesion(login);
                Usuario usuario = GestorUsuario.consultarUsuarioPorNombreDeUsuario(login.NombreDeUsuario);

                if (!(cuenta.Usuario.NombreDeUsuario.ToString() == usuario.NombreDeUsuario.ToString()))
                {
                    return Content(HttpStatusCode.Forbidden, "Esta cuenta no pertenece al usuario correspondiente.");
                }
            }
            catch (UnauthorizedAccessException e)
            {
                return Content(HttpStatusCode.Unauthorized, e.Message);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("Sesion de usuario null --> " + e);
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
                return Content(HttpStatusCode.Conflict, "No se pudo registrar la operación deposito --> " + e.Message);
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
            catch (CvuInvalido e)
            {
                return Content(HttpStatusCode.Forbidden, e.Message);
            }

            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, "No se encontró una cuenta con ese CVU --> " + e.Message);
            }
            try
            {
                LoginController.ValidarSesion(login);
                Usuario usuario = GestorUsuario.consultarUsuarioPorNombreDeUsuario(login.NombreDeUsuario);

                if (!(cuenta.Usuario.NombreDeUsuario.ToString() == usuario.NombreDeUsuario.ToString()))
                {
                    return Content(HttpStatusCode.Forbidden, "Esta cuenta no pertenece al usuario correspondiente.");
                }

            }
            catch (UnauthorizedAccessException e)
            {
                return Content(HttpStatusCode.Unauthorized, e.Message);
            }
            catch (HttpRequestException e)
            {
                return BadRequest("Sesion de usuario null --> " + e);
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
            catch(SaldoInsuficiente e)
            {
                return Content(HttpStatusCode.Forbidden, e.Message);
            }

            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, "No se pudó registrar la operación extracción --> " + e.Message);
            }
            //por ahora no se valida la sesion ni nada, simplemente se devuelven las operaciones del usuario
            //if (!LoginController.ValidarToken(sesion))return Unauthorized();
        }

    }
}
