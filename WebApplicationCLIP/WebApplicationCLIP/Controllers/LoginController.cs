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
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Cryptography;

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
                var token = GenerarToken(login.NombreDeUsuario);
                return Ok(new SesionDeUsuario(login.NombreDeUsuario, token));
            }
            else
            {
                return Content(HttpStatusCode.Unauthorized,"el usuario o la contraseña no son validos");
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

        public static string Encriptar(string texto) {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }

        public static string GenerarToken(string NombreDeUsuario)
        {
            NombreDeUsuario = NombreDeUsuario.ToLower();
            return Encriptar(NombreDeUsuario+"aaa");

            /*
            // var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            // var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var tokenHandler = new JwtSecurityTokenHandler();

            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, NombreDeUsuario) });


            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                //audience: audienceToken,
                //issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);

            return jwtTokenString;       */
              
        }

        public static bool ValidarToken(SesionDeUsuario sesion)
        {
            //aca hay que validar el token y verificar que corresponda al usuario
                        
            string nombre = sesion.NombreDeUsuario.ToLower();
            string token = sesion.Token;

            if (GenerarToken(nombre) == token)
            {
                return true;
            }
            else return false;
        }

        private int ValidarCredencial(string nombreUsuario, string contraseña)
        {
            /* aca va la consulta a la BD*/

            GestorUsuario gestorUsuario = new GestorUsuario();            
            return gestorUsuario.consultarCredencialesUsuario(nombreUsuario, contraseña);
        }
    }
}
