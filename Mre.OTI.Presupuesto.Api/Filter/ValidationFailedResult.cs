using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Mre.tecnologia.util.lib.Filter
{
    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new JsonErrorResponse(modelState))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }

        public ValidationFailedResult(JsonErrorResponse error, bool esError)
            : base(new JsonErrorResponse(error.Messages, error.DeveloperMessage))
        {
            if (esError)
                StatusCode = StatusCodes.Status500InternalServerError;
            else
                StatusCode = StatusCodes.Status400BadRequest;

        }
    }

    public class JsonErrorResponse
    {
        public string[] Messages { get; private set; }
        public object DeveloperMessage { get; private set; }

        public JsonErrorResponse(ModelStateDictionary modelState)
        {
            Messages = modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x => x.ErrorMessage)).ToArray();
        }

        public JsonErrorResponse(string[] messages, object developerMessage = null)
        {
            Messages = messages;
            //DeveloperMessage = developerMessage;
        }

    }
}
