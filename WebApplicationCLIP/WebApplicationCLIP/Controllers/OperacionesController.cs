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
            int cantidadOperaciones;
            try
            {
                cantidadOperaciones = (int)obj["cantidad"];
            }
            catch
            {
                cantidadOperaciones = 10;
            }

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
                //Operacion o = Operacion.crearOperacionExtraccion(null, monto);
                return Ok(cuenta.Depositar(monto));
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
                //Operacion o = Operacion.crearOperacionExtraccion(null, monto);
                return Ok(cuenta.Extraer(monto));
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

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("post/transferir")]
        public IHttpActionResult Transferir(JObject obj)
        //public IHttpActionResult DepositarMonto(float monto, string cvu, [FromBody] SesionDeUsuario login)
        {
            float monto = (float)obj["Monto"];
            string cvuOrigen = (string)obj["CvuOrigen"];
            string cvuDestino = (string)obj["CvuDestino"];
            string referencia = (string)obj["Referencia"];
            Transferencia.CategoriaTransferencia categoria;
            try
            {
                categoria = obj["Categoria"].ToObject<Transferencia.CategoriaTransferencia>();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Forbidden, new ErrorTransferencia("No existe esa categoria").Message);
            }
            
            SesionDeUsuario login = obj["SesionDeUsuario"].ToObject<SesionDeUsuario>();
            Cuenta cuentaOrigen;
            Cuenta cuentaDestino;

            try
            {
                CuentaDAO cuentaDAO = new CuentaDAO();
                cuentaOrigen = cuentaDAO.consultar(cvuOrigen);
                cuentaDestino = cuentaDAO.consultar(cvuDestino);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.ExpectationFailed, "No se encontró una cuenta con ese CVU --> " + e.Message);
            }

            try
            {
                LoginController.ValidarSesion(login);
                Usuario usuario = GestorUsuario.consultarUsuarioPorNombreDeUsuario(login.NombreDeUsuario);

                if (!(cuentaOrigen.Usuario.NombreDeUsuario.ToString() == usuario.NombreDeUsuario.ToString()))
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
                //Operacion o = Operacion.crearOperacionExtraccion(null, monto);
                Transferencia transferencia = cuentaOrigen.Transferir(cuentaDestino, monto, referencia, categoria);
                transferencia.BorrarDatosEscenciales();
                return Ok(transferencia);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            //por ahora no se valida la sesion ni nada, simplemente se devuelven las operaciones del usuario
            //if (!LoginController.ValidarToken(sesion))return Unauthorized();
        }

        //api de prueba de juan
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("get/transferencias")]
        public IHttpActionResult GetTransferencias(JObject obj)
        {
            int cantidadTransferencias;
            try
            {
                cantidadTransferencias = (int)obj["cantidad"];
            }
            catch 
            {
                cantidadTransferencias = 10;                
            }

            string tipoOperacion = "transferencia";
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
                return BadRequest("Sesion de usuario null --> " + e.Message);
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            try
            {
                GestorTransferencia gestorTransferencia = new GestorTransferencia();
                return Ok(gestorTransferencia.ObtenerTransferenciasPorCVU(cvu,tipoOperacion));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.Conflict, e.Message);
            }
            //por ahora no se valida la sesion ni nada, simplemente se devuelven las operaciones del usuario
            //if (!LoginController.ValidarToken(sesion))return Unauthorized();
        }

    }
}
