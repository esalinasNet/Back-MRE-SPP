using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Mre.OTI.Presupuesto.Api.IoC;

using Mre.OTI.Passport.util.documentos.backend;
using Mre.tecnologia.util.lib.Filter;
using System;

namespace Mre.OTI.Presupuesto.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

          
           // services.AddSingleton<ApiKeyService>(); // Registramos nuestro servicio
      
            
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API PRESUPUESTO - SPP ",
                    TermsOfService = new Uri("https://rree.gob.pe/oti"),
                    Contact = new OpenApiContact
                    {
                        Name = "OTI",
                        Email = string.Empty,
                        Url = new Uri("https://rree.gob.pe/spp/contact"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://rree.gob.pe/spp/license"),
                    }
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Ingrese el token en el formato: Bearer {token}"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            services.AddMvcCore(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                options.Filters.Add(typeof(ModelStateFilter));

            }).AddAuthorization()
                .AddFluentValidation();

            services.AddScoped<ValidateMimeMultipartContentFilter>();
            services.AddMediatR(AppDomain.CurrentDomain.Load("Mre.OTI.Passport.Application"));

            services.AddAutoMapper(AppDomain.CurrentDomain.Load("Mre.OTI.Passport.Application"));

            services.RegisterInfrastructureServices(Configuration);
            services.RegisterSecurityServices(Configuration);
            services.RegisterCoreServices(Configuration);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var urlAceptadas = Configuration.GetSection("AllowedOrigins").Value.Split(",");
            app.UseCors();
            app.UseCors(builder => builder
                 .WithOrigins(urlAceptadas)
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .WithExposedHeaders("X-Token-Expired")

                 );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var useHttpsRedirection = Configuration.GetSection("UseHttpsRedirection").Value;
            if (Convert.ToBoolean(useHttpsRedirection))
            {
                app.UseHttpsRedirection();
            }


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Añadimos nuestro middleware de validación de API Key
           // app.UseMiddleware<ApiKeyMiddleware>();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "OTI");
                });
            }

             
        }
    }
}
