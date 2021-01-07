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
            string domi = (string)obj["Domicilio"];
            string email = (string)obj["Email"];
            string tel = (string)obj["Telefono"];
            SesionDeUsuario login = obj["SesionDeUsuario"].ToObject<SesionDeUsuario>();
            try
            {
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                usuarioDAO.modificarDatosUsuario(domi, email, tel, login);
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
