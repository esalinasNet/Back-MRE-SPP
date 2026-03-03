

using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Command;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Queries;
using Mre.OTI.Presupuesto.Application.Features.Catalogo.Validators;




namespace Mre.OTI.Presupuesto.Api.IoC
{
    public static class ApplicationExtensions
    {
        public static void RegisterCoreServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IValidator<AgregarCatalogoViewModel>, AgregarCatalogoValidator>();
            services.AddTransient<IValidator<ActualizarCatalogoViewModel>, ActualizarCatalogoValidator>();
            services.AddTransient<IValidator<EliminarCatalogoViewModel>, EliminarCatalogoValidator>();
            services.AddTransient<IValidator<ObtenerCatalogoPaginadoViewModel>, ObtenerCatalogoPaginadoValidator>();
            services.AddTransient<IValidator<ObtenerCatalogoViewModel>, ObtenerCatalogoValidator>();
        }
    }
}
