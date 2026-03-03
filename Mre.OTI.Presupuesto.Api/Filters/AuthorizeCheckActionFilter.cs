using Mre.OTI.Presupuesto.Application.Features.Autenticacion.Command;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mre.OTI.Presupuesto.Application.Features.Seguridad.Queries;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using MediatR;
using System.ServiceModel.Channels;
using Mre.OTI.Presupuesto.Domain.Setting;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Passport.Util.Encriptador;

namespace HEP.Seguridad.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeCheckActionFilter : TypeFilterAttribute
    {
        public AuthorizeCheckActionFilter(ActionCode accessType = ActionCode.NONE) : base(typeof(AuthorizeCheckActionImplFilter))
        {
            Arguments = new object[] { accessType };
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeCheckActionImplFilter : ActionFilterAttribute
    {
        public string _urlAuthorization;
        private readonly ActionCode _accessType;
        private readonly IMediator _IMediator;
        public AuthorizeCheckActionImplFilter(IMediator iMediator, ActionCode accessType = ActionCode.NONE)
        {
            _accessType = accessType;
            _IMediator = iMediator;
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            string token, idPerfil, idOpcion, accion, idSistema;
           
           var msg = new List<string>();
            var httpRequest = actionContext.HttpContext.Request;
            var swagger = httpRequest.Headers["Referer"];
            if (swagger.Count > 0 && swagger[0].Contains("swagger"))
            {
                if (!TryRetrieveToken(actionContext.HttpContext.Request))
                {
                    var mensajeJson = new JObject();
                    mensajeJson["HasErrors"] = true;
                    mensajeJson["Message"] = "Unauthorized request";
                    actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    actionContext.Result = new JsonResult(new { HttpStatusCode.Unauthorized, mensajeJson });
                }
            }
            else if (TryRetrieveToken(actionContext.HttpContext.Request, out token, out idPerfil, out idOpcion, out accion, out idSistema))
            {
                if (_accessType != ActionCode.NONE)
                {
                    accion = CodigoAccion.GetAccessTypeString(this._accessType);
                }

                try
                {
                    //var _idSistema = Convert.ToInt32(UrlEncryptationSecurity.Decrypt(idSistema));
                    //var _idPerfil = Convert.ToInt32(UrlEncryptationSecurity.Decrypt(idPerfil));
                    //var _accion = EncryptionPassportHandler.Decrypt(accion, Constantes.SISTEMA.KEY_ENCRYPT);

                    var _idSistema = 1;// Convert.ToInt32(idSistema);
                    var _idPerfil = Convert.ToInt32(idPerfil);
                    var _accion = accion;

                    ObtenerAutorizacionViewModel request = new ObtenerAutorizacionViewModel
                    {
                        IdSistema =_idSistema,
                        IdOpcion = Convert.ToInt32(idOpcion),
                        IdPerfil = _idPerfil,
                        Accion = _accion
                    };
                    var permision = _IMediator.Send(request).Result;
                    if (permision.IsAuthorized)
                    {
                        actionContext.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(
                                      new[] {
                                    new Claim("UserLogin", ""),
                                    new Claim("Token", token),
                                    new Claim("idOpcion", idOpcion),
                                    new Claim("idPerfil", idPerfil)
                                      }
                                  ));
                    }
                    else
                    {

                        msg.Add("Ud. no tiene autorización para realizar esta acción.".ToUpper());
                        actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                        actionContext.Result = new JsonResult(new { HttpStatusCode.ServiceUnavailable, HasErrors = true, Messages = msg });
                    }
                }
                catch (Exception ex)
                {

                    msg.Add($"Ha ocurrido in the solicitud: {ex.Message}");
                    actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    actionContext.Result = new JsonResult(new { HttpStatusCode.InternalServerError, HasErrors = true, Messages = msg });
                }
            }
            else
            {
                msg.Add($"Información no autorizada en la solicitud. Múltiples parámetros no fueron enviados".ToUpper());
                actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                actionContext.Result = new JsonResult(new { HttpStatusCode.BadRequest, HasErrors = true, Messages = msg });

            }

            

            base.OnActionExecuting(actionContext);
        }

        private bool TryRetrieveToken(HttpRequest request, out string token, out string idPerfil, out string idOpcion, out string accion, out string idSistema)
        {
            try
            {
                token = string.Empty;
                idPerfil = string.Empty;
                idOpcion = string.Empty;
                accion = string.Empty;
                idSistema = string.Empty;

                var authHeaders = request.Headers["Authorization"];
                if (authHeaders.Count == 0)
                {
                    return false;
                }
                var bearerToken = authHeaders[0];
                token = bearerToken.StartsWith("Bearer ", StringComparison.CurrentCultureIgnoreCase) ? bearerToken.Substring(7) : bearerToken;


                var perfilHeaders = request.Headers["idPerfil"];
                if (perfilHeaders.Count == 0)
                {
                    return false;
                }
                idPerfil = perfilHeaders[0];

                var opcionHeaders = request.Headers["idOpcion"];
                if (opcionHeaders.Count == 0)
                {
                    return false;
                }
                idOpcion = opcionHeaders[0];

                var accionHeaders = request.Headers["accion"];
                if (accionHeaders.Count == 0)
                {
                    return false;
                }
                accion = accionHeaders[0];

                var sistemaHeaders = request.Headers["idSistema"];
                if (sistemaHeaders.Count == 0)
                {
                    return false;
                }
                idSistema = sistemaHeaders[0];

                return true;
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred in the verification of the request parameters {e.Message}".ToUpper());
            }
        }

        private bool TryRetrieveToken(HttpRequest request)
        {
            bool validado = false;

            try
            {
                string token = string.Empty;

                var authHeaders = request.Headers["Authorization"];
                if (authHeaders.Count > 0)
                {
                    var bearerToken = authHeaders[0];
                    token = bearerToken.StartsWith("Bearer ", StringComparison.CurrentCultureIgnoreCase) ? bearerToken.Substring(7) : bearerToken;

                    // it needs to validate the token, in this case I assume the token is correct
                    validado = true;
                }

            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while checking the request parameters {e.Message}");
            }

            return validado;
        }
    }
    public class GenericMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public int Type { get; set; }
    }

    public enum ActionCode
    {
        /// <summary>
        /// Access
        /// </summary>
        [StringValue("ACC")]
        ACCESS,
        /// <summary>
        /// List rows
        /// </summary>
        [StringValue("LST")]
        LIST,
        /// <summary>
        /// Add new row
        /// </summary>
        [StringValue("ADD")]
        ADD,
        /// <summary>
        /// Update row
        /// </summary>
        [StringValue("UPD")]
        UPDATE,
        /// <summary>
        /// Delete row
        /// </summary>
        [StringValue("DEL")]
        DELETE,
        /// <summary>
        /// Aprove Row
        /// </summary>
        [StringValue("APR")]
        APROVE,
        /// <summary>
        /// Reject Row
        /// </summary>
        [StringValue("REJ")]
        REJECT,
        /// <summary>
        /// View Row
        /// </summary>
        [StringValue("VIW")]
        VIEW,
        /// <summary>
        /// Submit Row
        /// </summary>
        [StringValue("SUB")]
        SUBMIT,
        [StringValue("")]
        NONE
    }

    internal class StringValueAttribute : Attribute
    {
        public string Valor { get; private set; }
        public StringValueAttribute(string v)
        {
            this.Valor = v;
        }
    }

    public class CodigoAccion
    {
        public static string GetAccessTypeString(ActionCode tIPO_ACCESO)
        {
            return tIPO_ACCESO.GetAttributeOfType<StringValueAttribute>().Valor;
        }
    }

    public static class EnumExtensions
    {
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }

}
