using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Mre.OTI.Presupuesto.Application.Responses.Planillas_Detalle;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas_Detalle.Queries
{
    public class ObtenerPlanillasDetalleQuery : IRequestHandler<ObtenerPlanillasDetalleViewModel, ObtenerPlanillasDetalleResponseViewModel>
    {
        readonly private IPlanillasDetalleRepository _IPlanillasDetalleRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerPlanillasDetalleQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPlanillasDetalleRepository IPlanillasDetalleRepository, IMapper mapper)
        {
            _IPlanillasDetalleRepository = IPlanillasDetalleRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerPlanillasDetalleResponseViewModel> Handle(ObtenerPlanillasDetalleViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
             VariablesGlobales.TablaRol.ANALISTA_OGTH
         });

            var dto = PlanillasDetalleMap.MaptoDTO(request);

            var _result = await _IPlanillasDetalleRepository.ObtenerPlanillasDetalle(dto);

            if (request.idPlanillaDetalle == 0) throw new MreException("ingrese idPlanillasDetalle");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerPlanillasDetalleResponseViewModel>(_result);
        }
    }

}
