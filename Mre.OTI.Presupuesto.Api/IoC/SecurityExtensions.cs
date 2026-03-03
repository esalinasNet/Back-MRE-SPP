
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Mre.OTI.Presupuesto.Domain.Setting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mre.OTI.Presupuesto.Api.IoC
{
    public static class SecurityExtensions
    {
        public static void RegisterSecurityServices(this IServiceCollection services, IConfiguration Configuration)
        {
            Error error = new Error();
            var msgs = new List<string>();

            services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
            services.Configure<LDAPSettings>(Configuration.GetSection("LDAPSettings"));
            services.Configure<DocumentoSettings>(Configuration.GetSection("DocumentoSettings"));
            services.Configure<LoginSettings>(Configuration.GetSection("LoginSettings"));
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));

            

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = Configuration["JWTSettings:Issuer"],
                    ValidAudience = Configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTSettings:Key"]))
                };

                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = context =>
                    {
                        context.NoResult();
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";

                        msgs.Clear();
                        msgs.Add("El token del usuario a expirado. Vuelva a iniciar su sesión");
                        error = new Error { messages = msgs };

                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("X-Token-Expired", "true");
                        }


                        var result = JsonConvert.SerializeObject(error);
                        return context.Response.WriteAsync(result);


                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";

                        context.Request.Headers.TryGetValue("Authorization", out var BearerToken);

                        msgs.Clear();
                        if (string.IsNullOrEmpty(BearerToken))
                        {
                            msgs.Add("El usuario no ha generado token de acceso.");
                            context.Response.Headers.Add("X-Token-Not-Sent", "true");
                        }
                        if (msgs.Count() == 0 && BearerToken.Count == 0)
                        {
                            msgs.Add("El usuario no ha generado token de acceso..");
                            context.Response.Headers.Add("X-Token-Not-Sent", "true");
                        }
                        if (msgs.Count() == 0 && BearerToken.Count == 1 && BearerToken[0] == "Bearer null")
                        {
                            msgs.Add("El usuario no ha generado token de acceso...");
                            context.Response.Headers.Add("X-Token-Not-Sent", "true");
                        }
                        if (msgs.Count() == 0)
                        {
                            msgs.Add("El usuario no se encuentra autorizado autorizado para acceder al recurso:" + BearerToken);
                            context.Response.Headers.Add("X-Token-Not-Sent", "true");
                        }

                        error = new Error { messages = msgs };



                        var result = JsonConvert.SerializeObject(error);
                        return context.Response.WriteAsync(result);
                    },
                    OnForbidden = context =>
                   {
                       context.Response.StatusCode = 400;
                       context.Response.ContentType = "application/json";
                       msgs.Clear();
                       msgs.Add("No tiene permisos sobre este recurso");
                       error = new Error { messages = msgs };

                       var result = JsonConvert.SerializeObject(error);
                       return context.Response.WriteAsync(result);
                   }//,
                    //OnMessageReceived= context =>
                    //{
                    //   var message = "From OnMessageReceived:\n";
                    //    context.Request.Headers.TryGetValue("Authorization", out var BearerToken);
                    //    if (BearerToken.Count == 0)          BearerToken = "no Bearer token sent\n";
                    //    message += "Authorization Header sent: " + BearerToken + "\n";

                   //    msgs.Clear();
                   //    msgs.Add(message);
                   //    error = new Error { messages = msgs };

                   //    var result = JsonConvert.SerializeObject(error);
                   //    return context.Response.WriteAsync(result);

                   //  //  return Task.CompletedTask;
                   //},


                };




            });
        }
    }
}
