﻿using System;
using System.Collections.Generic;
using System.Net;
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
        [Route("usuario")]

        public IHttpActionResult GetOperacionesUsuario(SesionDeUsuario sesion, int cantidadDeOperaciones)
        {
            if (sesion== null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //por ahora no se valida la sesion ni nada, simplemente se devuelven las operaciones del usuario
            //if (!LoginController.ValidarToken(sesion))return Unauthorized();
            
            return Ok(Operacion.ObtenerOperacionesDePrueba());
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("usuario")]

        public IHttpActionResult GetDatosUsuario(SesionDeUsuario login)
        {
            if (login == null)
                return Content(HttpStatusCode.BadRequest,"sesion de usuario expirada");
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            if (!LoginController.ValidarToken(login)){
                //token invalido
                return Content(HttpStatusCode.Unauthorized, "token de usuario invalido");                
            }

            string nombreUsuario = login.NombreDeUsuario;
            Usuario usuario = Usuario.CrearUsuarioConNombreDeUsuario(nombreUsuario);            
            UsuarioDAOImp usuarioDAO = new UsuarioDAOImp();

            if (usuarioDAO.consultar(usuario)==0)
            {
                return Ok(usuario);
            }
            return Content(HttpStatusCode.Conflict, 1);
            

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
