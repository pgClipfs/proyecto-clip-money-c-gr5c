using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using WebApplicationCLIP.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel;
using System.Web.Http.Cors;
using WebApplicationCLIP.Gestores;
using Newtonsoft.Json.Linq;

namespace WebApplicationCLIP.Controllers
{

    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing() { return Ok(true); }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUsuario() {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]        
        [Route("authenticate")]

        public IHttpActionResult Authenticate(SolicitudLogin login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            int respuesta = ValidarCredencial(login.NombreDeUsuario, login.Contraseña);

            if (respuesta==0)
            {
                //var token = GenerarToken(login.NombreDeUsuario);
                Console.Write(login.NombreDeUsuario);
                var token = "asd";
                return Ok(new SesionDeUsuario(login.NombreDeUsuario, token));
            }
            else
            {
                return Content(HttpStatusCode.Conflict,respuesta);
            }

        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("registerUser")]

        public IHttpActionResult RegisterUser(JObject usuarioJSON)
        {

            if (usuarioJSON == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Usuario usuario = Usuario.CrearUsuarioConJObject(usuarioJSON);
            GestorUsuario gestor = new GestorUsuario();

            int respuesta = gestor.registrarUsuario(usuario);

            if (respuesta == 0)
            {
                return Ok();
            }
            else
            {
                return Content(HttpStatusCode.Conflict, respuesta);
            }
        }

        public static bool ValidarToken(string token)
        {
            //por ahora siempre true, para no tener problemas con esto. despues veremos
            return true;
        }

        public static string GenerarToken(string NombreDeUsuario)
        {


            // es un JSON Web Token
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, NombreDeUsuario) });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        private int ValidarCredencial(string nombreUsuario, string contraseña)
        {
            /* Aqui va la consulta a la BD*/

            GestorUsuario gestorUsuario = new GestorUsuario();
            
            return gestorUsuario.consultarCredencialesUsuario(nombreUsuario, contraseña);


        }
    }
}
