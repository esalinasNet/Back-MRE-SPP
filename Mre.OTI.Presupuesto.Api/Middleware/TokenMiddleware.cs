using MediatR;
using Microsoft.AspNetCore.Http;
using Mre.OTI.Passport.Application.Repositories;
//using Mre.OTI.Passport.Application.Features.ApiKey.Queries;
using Mre.OTI.Passport.Infraestructure.Services;
using System.Threading.Tasks;

namespace Mre.OTI.Passport.Api.Middleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenService _tokenService;

        public TokenMiddleware(RequestDelegate next, TokenService tokenService)
        {
            _next = next;
            _tokenService = tokenService;
             
        }

        public async Task InvokeAsync(HttpContext context)
        {

            if (!context.Request.Headers.TryGetValue("Authorization", out var token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Token is missing");
                return;
            }

            if (!await _tokenService.ValidateTokenAsync(token,""))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Token is invalid or expired");
                return;
            }

            
            await _next(context);
        }
    }
}
