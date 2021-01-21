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
    public class UsuarioController : ApiController
    {

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

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("post/modificardatosusuario")]
        public IHttpActionResult ModificarDatos(JObject obj)
        //public IHttpActionResult DepositarMonto(float monto, string cvu, [FromBody] SesionDeUsuario login)
        {
            Usuario usu = new Usuario(obj["usuario"].ToObject<JObject>());
            SesionDeUsuario login = obj["SesionDeUsuario"].ToObject<SesionDeUsuario>();
            try
            {
                LoginController.ValidarSesion(login);

                if (login.NombreDeUsuario!=usu.NombreDeUsuario)
                {
                    throw new UnauthorizedAccessException();
                }
            }
            catch (UnauthorizedAccessException e)
            {
                return Content(HttpStatusCode.Unauthorized, e.Message);
            }
            try
            {
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                usuarioDAO.modificar(usu);
                return Ok("Sus datos han sido modificados correctamente.");
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
    }
}
