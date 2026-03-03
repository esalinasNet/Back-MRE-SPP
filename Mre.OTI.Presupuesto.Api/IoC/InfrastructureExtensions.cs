using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Repositories.Services;
using Mre.OTI.Presupuesto.Application.Services;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Presupuesto.Infraestructure;
using Mre.OTI.Presupuesto.Infraestructure.Repositories;
using Mre.OTI.Presupuesto.Infraestructure.Services;
using Mre.OTI.Passport.Util.Encriptador;
using System;

namespace Mre.OTI.Presupuesto.Api.IoC
{
    public static class InfrastructureExtensions
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped(x => new DBConnection(EncryptionPassportHandler.Decrypt(Configuration.GetConnectionString("sql-bd"), Constantes.SISTEMA.KEY_ENCRYPT)));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICatalogoItemRepository, CatalogoItemRepository>();
            services.AddTransient<ICatalogoRepository, CatalogoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<IUsuarioRolRepository, UsuarioRolRepository>();
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            services.AddTransient<IDocumentosAdjuntosRepository, DocumentosAdjuntosRepository>();
            services.AddTransient<ILogSessionRepository, LogSessionRepository>();
            services.AddTransient<ISeguridadRepository, SeguridadRepository>();
            services.AddTransient<IFuncionRepository, FuncionRepository>();
            services.AddTransient<IAniosRepository, AniosRepository>();
            services.AddTransient<IEspecificaGastoRepository, EspecificaGastoRepository>();
            services.AddTransient<IProgramaRepository, ProgramaRepository>();
            services.AddTransient<ISubProgramaRepository, SubProgramaRepository>();
            services.AddTransient<IComponenteRepository, ComponenteRepository>();
            services.AddTransient<IActividadRepository, ActividadRepository>();
            services.AddTransient<IPaisesRepository, PaisesRepository>();
            services.AddTransient<ISistemaRepository, SistemaRepository>();            
            services.AddTransient<IUbigeoRepository, UbigeoRepository>();
            services.AddTransient<IUbigeoExteriorRepository, UbigeoExteriorRepository>();
            services.AddTransient<ITipoDeCambioRepository, TipoDeCambioRepository>();
            services.AddTransient<ICalendarioRepository, CalendarioRepository>();
            services.AddTransient<ICentroCostosRepository, CentroCostosRepository>();
            services.AddTransient<IPoliticasRepository, PoliticasRepository>();
            services.AddTransient<IOjetivosRepository, ObjetivosRepository>();
            services.AddTransient<IAccionesRepository, AccionesRepository>();
            services.AddTransient<IOjetivosInstitucionalesRepository, ObjetivosInstitucionalesRepository>();
            services.AddTransient<IAccionesInstitucionalesRepository, AccionesInstitucionalesRepository>();
            services.AddTransient<IFasesPoiRepository, FasesPoiRepository>();
            services.AddTransient<IAeiCentroCostosRepository, AeiCentroCostosRepository>();
            services.AddTransient<ICategoriaPresupuestalRepository, CategoriaPresupuestalRepository>();
            services.AddTransient<IAeiCategoriaPresupuestalRepository, AeiCategoriaPresupuestalRepository>();
            services.AddTransient<IDivisionFuncionalRepository, DivisionFuncionalRepository>();
            services.AddTransient<IGrupoFuncionalRepository, GrupoFuncionalRepository>();
            services.AddTransient<IUnidadMedidaRepository, UnidadMedidaRepository>();
            services.AddTransient<IFinalidadRepository, FinalidadRepository>();
            services.AddTransient<IProgramacionActividadRepository, ProgramacionActividadRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IFuenteFinanciamientoRepository, FuenteFinanciamientoRepository>();
            services.AddTransient<IProgramacionTareasRepository, ProgramacionTareasRepository>();
            services.AddTransient<IProgramacionAccionesRepository, ProgramacionAccionesRepository>();
            services.AddTransient<IProgramacionClasificadorRepository, ProgramacionClasificadorRepository>();
            services.AddTransient<IBienesServiciosRepository, BienesServiciosRepository>();
            services.AddTransient<IPlanillasRepository, PlanillasRepository>();
            services.AddTransient<IPlanillasDetalleRepository, PlanillasDetalleRepository>();
            services.AddTransient<IAprobacionesCostosRepository, AprobacionesCostosRepository>();
            services.AddTransient<IAprobacionesCostosDetalleRepository, AprobacionesCostosDetalleRepository>();

            services.AddTransient<IRecursoRepository, RecursoRepository>();
            services.AddTransient<ICmnRepository, CmnRepository>();
            services.AddTransient<IProyectoRepository, ProyectoRepository>();
            services.AddTransient<IViaticosRepository, ViaticosRepository>();
            services.AddTransient<IOtrosGastosRepository, OtrosGastosRepository>();
            services.AddTransient<IEncargosRepository, EncargosRepository>();
            services.AddTransient<ICajaChicaRepository, CajaChicaRepository>();
            services.AddTransient<IProgramacionAniosRepository, ProgramacionAniosRepository>();
            services.AddTransient<IPlanillaRepository, PlanillaRepository>();
            services.AddTransient<IReporteRepository, ReporteRepository>();
            services.AddTransient<ICmnDetalleRepository, CmnDetalleRepository>();
            services.AddTransient<ICajaChicaDetalleRepository, CajaChicaDetalleRepository>();
            services.AddTransient<IViaticosDetalleRepository, ViaticosDetalleRepository>();
            services.AddTransient<IEncargosDetalleRepository, EncargosDetalleRepository>();
            services.AddTransient<IOtrosGastosDetalleRepository, OtrosGastosDetalleRepository>();
            services.AddTransient<IProyectoDetalleRepository, ProyectoDetalleRepository>();
            services.AddTransient<IReporteFinancieroRepository, ReporteFinancieroRepository>();

            services.AddHttpClient<IDocumentoService, SubirDocumentoService>(c => c.BaseAddress = new Uri(Configuration["apiDocumento"]));
            services.AddHttpClient<IAccionesGrabadasService, AccionesGrabadasService>(c => c.BaseAddress = new Uri(Configuration["apiAccionesGrabadas"]));

        }
    }
}
