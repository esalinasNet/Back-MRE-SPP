using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Planilla;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Planilla.Queries
{
    public class ObtenerPlanillaPorIdQuery : IRequestHandler<ObtenerPlanillaPorIdViewModel, ObtenerPlanillaPorIdResponseViewModel>
    {
        private readonly IPlanillaRepository _IPlanillaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerPlanillaPorIdQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IPlanillaRepository IPlanillaRepository,
            IMapper mapper)
        {
            _IPlanillaRepository = IPlanillaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerPlanillaPorIdResponseViewModel> Handle(ObtenerPlanillaPorIdViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                    VariablesGlobales.TablaRol.ANALISTA_OGTH
                });

                var result = await _IPlanillaRepository.ObtenerPlanillaPorId(request.idProgramacionPlanilla, request.usuarioConsulta);

                if (result == null)
                {
                    return null;
                }

                return PlanillaMap.MaptoViewModelPorId(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}