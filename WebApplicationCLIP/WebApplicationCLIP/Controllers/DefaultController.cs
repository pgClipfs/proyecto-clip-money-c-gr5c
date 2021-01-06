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

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("prueba1")]
        public IHttpActionResult prueba()
        {
            Usuario usu = GestorUsuario.consultarUsuarioPorNombreDeUsuario("stephie");
            Cuenta cuenta = new Cuenta("1234", usu);

            CuentaDAO c = new CuentaDAO();

            try
            {
                c.registrar(cuenta);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e);
            }

            return Ok();
        }


        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("ping")]
        public IHttpActionResult ping()
        {   
            return Ok();
        }

    }
}