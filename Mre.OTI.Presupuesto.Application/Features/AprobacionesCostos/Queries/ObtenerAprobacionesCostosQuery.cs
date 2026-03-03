using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Queries
{    
    public class ObtenerAprobacionesCostosQuery : IRequestHandler<ObtenerAprobacionesCostosViewModel, ObtenerAprobacionesCostosResponseViewModel>
    {
        readonly private IAprobacionesCostosRepository _IAprobacionesCostosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerAprobacionesCostosQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAprobacionesCostosRepository IAprobacionesCostosRepository, IMapper mapper)
        {
            _IAprobacionesCostosRepository = IAprobacionesCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerAprobacionesCostosResponseViewModel> Handle(ObtenerAprobacionesCostosViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
               VariablesGlobales.TablaRol.ANALISTA_OGTH
           });

            var dto = AprobacionesCostosMap.MaptoDTO(request);

            var _result = await _IAprobacionesCostosRepository.ObtenerAprobacionesCostos(dto);

            if (request.idAprobaciones == 0) throw new MreException("ingrese idAprobaciones");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerAprobacionesCostosResponseViewModel>(_result);
        }
    }
}
