using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Reporte;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.ReporteFinanciero.Queries
{
    public class ObtenerReporteFinancieroQuery : IRequestHandler<ObtenerReporteFinancieroViewModel, ObtenerReporteFinancieroResponseViewModel>
    {
        private readonly IReporteFinancieroRepository _IReporteFinancieroRepository;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerReporteFinancieroQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IReporteFinancieroRepository IReporteFinancieroRepository)
        {
            _IReporteFinancieroRepository = IReporteFinancieroRepository;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerReporteFinancieroResponseViewModel> Handle(ObtenerReporteFinancieroViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var result = await _IReporteFinancieroRepository.ObtenerReporteFinanciero(request.idProgramacionActividad);
                return ReporteFinancieroMap.MaptoViewModel(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}