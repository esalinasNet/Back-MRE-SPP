using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Reporte;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Reporte.Queries
{
    public class ObtenerReporteActividadQuery : IRequestHandler<ObtenerReporteActividadViewModel, ObtenerReporteActividadResponseViewModel>
    {
        private readonly IReporteRepository _IReporteRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerReporteActividadQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IReporteRepository IReporteRepository)
        {
            _IReporteRepository = IReporteRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerReporteActividadResponseViewModel> Handle(ObtenerReporteActividadViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var result = await _IReporteRepository.ObtenerReporteActividad(request.idProgramacionActividad);
                return ReporteMap.MaptoViewModel(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}