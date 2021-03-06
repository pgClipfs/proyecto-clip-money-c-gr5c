﻿using System;
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
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(SolicitudLogin login)
        {
            try
            {
                if (login == null) throw new HttpRequestException();

                if (ValidarCredencial(login.NombreDeUsuario, login.Contraseña))
                {
                    //var token = GenerarToken(login.NombreDeUsuario);
                    Console.Write(login.NombreDeUsuario);
                    var token = GenerarToken(login.NombreDeUsuario);
                    return Ok(new SesionDeUsuario(login.NombreDeUsuario, token));
                }
                else
                {
                    return Content(HttpStatusCode.Unauthorized, "el usuario o la contraseña no son validos");
                }
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
        [Route("registerUser")]
        public IHttpActionResult RegisterUser(JObject usuarioJSON)
        {
            if (usuarioJSON == null)
                return BadRequest();

            Usuario usuario = new Usuario(usuarioJSON);
            GestorUsuario gestor = new GestorUsuario();

            try
            {
                gestor.registrarUsuario(usuario);
                usuario.CrearNuevaCuenta();
                return Ok("El usuario se registro exitosamente");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Forbidden, e.Message);
            }
        }

        public static void ValidarSesion(SesionDeUsuario login)
        {
            if (login == null)
            {
                throw new HttpRequestException();
            }

            try
            {
            GestorUsuario.consultarUsuarioPorNombreDeUsuario(login.NombreDeUsuario);
            }
            catch (Exception)
            {
                throw new UsuarioNoEncontrado(login.NombreDeUsuario);
            }

            if (!LoginController.ValidarToken(login))
            {
                throw new SesionExpirada();
            }
        }

        private static string Encriptar(string texto)
        {
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

        private static string GenerarToken(string NombreDeUsuario)
        {
            NombreDeUsuario = NombreDeUsuario.ToLower();
            return Encriptar(NombreDeUsuario + "aaa");

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

        private static bool ValidarToken(SesionDeUsuario sesion)
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

        private bool ValidarCredencial(string nombreUsuario, string contraseña)
        {
            /* aca va la consulta a la BD*/

            GestorUsuario gestorUsuario = new GestorUsuario();
            return gestorUsuario.consultarCredencialesUsuario(nombreUsuario, contraseña);
        }
    }
}
