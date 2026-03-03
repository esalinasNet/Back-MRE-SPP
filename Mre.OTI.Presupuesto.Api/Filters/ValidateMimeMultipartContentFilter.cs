using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
 

namespace Mre.OTI.Passport.util.documentos.backend
{
    public class ValidateMimeMultipartContentFilter : ActionFilterAttribute
    {
        public ValidateMimeMultipartContentFilter()
        {
            //Log.Information("Validator: Método ValidateMimeMultipartContentFilter");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!IsMultipartContentType(context.HttpContext.Request.ContentType))
            {
                context.Result = new StatusCodeResult(415);
                return;
            }

            base.OnActionExecuting(context);
        }

        private static bool IsMultipartContentType(string contentType)
        {
            return !string.IsNullOrEmpty(contentType) && contentType.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
