using Microsoft.AspNetCore.Mvc.Filters;
//using Mre.tecnologia.util.lib.Exceptions;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Newtonsoft.Json;
using Serilog;
using System.Net;

namespace Mre.tecnologia.util.lib.Filter
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public const string InternalError = "HUBO UN PROBLEMA AL PROCESAR LA SOLICITUD, INTENTE NUEVAMENTE POR FAVOR.";
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(MreException))
            {
                var json = new JsonErrorResponse(new[] { context.Exception.Message });
                context.Result = new ValidationFailedResult(json, false);

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = true;
            }
            else
            {
                var json = new JsonErrorResponse(new[] { InternalError }, context.Exception.Message);

                Log.Error(JsonConvert.SerializeObject(context.Exception));

                context.Result = new ValidationFailedResult(json, true);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = false;
            }

        }
    }
}
