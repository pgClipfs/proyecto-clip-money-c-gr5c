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
                        
            if (ValidarCredencial(login.NombreDeUsuario,login.Contraseña))
            {
                //var token = GenerarToken(login.NombreDeUsuario);
                var token = "asd";
                return Ok(new SesionDeUsuario(login.NombreDeUsuario, token));
            }
            else
            {
                return Unauthorized();
            }
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

        private bool ValidarCredencial(string nombreUsuario, string contraseña)
        {
            /* Aqui va la consulta a la BD*/

            GestorUsuario gestorUsuario = new GestorUsuario();
            return gestorUsuario.consultarCredencialesUsuario("martinp", "martinin7");
            
            
            /*
            if (nombreUsuario=="juan" && contraseña == "123")
            {
                return true;
            }

            return false;
            */


        }
    }
}
