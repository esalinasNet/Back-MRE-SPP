using MediatR;
using Microsoft.AspNetCore.Http;
using Mre.OTI.Passport.Application.Repositories;
//using Mre.OTI.Passport.Application.Features.ApiKey.Queries;
using Mre.OTI.Passport.Infraestructure.Services;
using System.Threading.Tasks;

namespace Mre.OTI.Passport.Api.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ApiKeyService _apiKeyService;

        public ApiKeyMiddleware(RequestDelegate next, ApiKeyService apiKeyService)
        {
            _next = next;
            _apiKeyService = apiKeyService;
             
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Api Key was not provided.");
                return;
            }
            if (!context.Request.Headers.TryGetValue("AppKey", out var extractedAppKey))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("App Api Key was not provided.");
                return;
            }
            var isValidApiKey = await _apiKeyService.ValidateApiKeyAsync(extractedAppKey, extractedApiKey);

            if (!isValidApiKey)
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Unauthorized client.");
                return;
            }

            await _next(context);
        }
    }
}
