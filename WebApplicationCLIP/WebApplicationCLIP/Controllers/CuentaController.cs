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
    public class CuentaController : ApiController
    {
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
                GestorCuenta gestorCuenta = new GestorCuenta();
                Cuenta c = gestorCuenta.TraerCuenta(cvu);
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
            if (login == null || login.NombreDeUsuario == null)
            {
                return BadRequest("bad request :o");
            }

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
                return Content(HttpStatusCode.ExpectationFailed, "No se encontró una cuenta con ese CVU --> " + e.Message);
            }
            try
            {
                LoginController.ValidarSesion(login);
                Usuario usuario = GestorUsuario.consultarUsuarioPorNombreDeUsuario(login.NombreDeUsuario);

                if (!(usuario.NombreDeUsuario.ToString() == usuario.NombreDeUsuario.ToString()))
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
                GestorCuenta gestorCuenta = new GestorCuenta();
                return Ok(gestorCuenta.ObtenerCuentasDelUsuario(login));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
        }



    }
}
