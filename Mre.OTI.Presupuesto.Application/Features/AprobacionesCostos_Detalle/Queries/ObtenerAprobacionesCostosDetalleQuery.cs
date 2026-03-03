using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos_Detalle;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos_Detalle.Queries
{    
    public class ObtenerAprobacionesCostosDetalleQuery : IRequestHandler<ObtenerAprobacionesCostosDetalleViewModel, ObtenerAprobacionesCostosDetalleResponseViewModel>
    {
        readonly private IAprobacionesCostosDetalleRepository _IAprobacionesCostosDetalleRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerAprobacionesCostosDetalleQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAprobacionesCostosDetalleRepository IAprobacionesCostosDetalleRepository, IMapper mapper)
        {
            _IAprobacionesCostosDetalleRepository = IAprobacionesCostosDetalleRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerAprobacionesCostosDetalleResponseViewModel> Handle(ObtenerAprobacionesCostosDetalleViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> { VariablesGlobales.TablaRol.ANALISTA_OGTH });

            var dto = AprobacionesCostosDetalleMap.MaptoDTO(request);

            var _result = await _IAprobacionesCostosDetalleRepository.ObtenerAprobacionesCostosDetalle(dto);

            if (request.idAprobacionesDetalle == 0) throw new MreException("ingrese idAprobacionesCostosDetalle");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerAprobacionesCostosDetalleResponseViewModel>(_result);
        }
    }
}
