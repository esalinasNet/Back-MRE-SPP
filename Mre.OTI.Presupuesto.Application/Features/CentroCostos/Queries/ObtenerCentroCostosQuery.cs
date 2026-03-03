using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CentroCostos;
using Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CentroCostos.Queries
{
    public class ObtenerCentroCostosQuery : IRequestHandler<ObtenerCentroCostosViewModel, ObtenerCentroCostosResponseViewModel>
    {
        private readonly ICentroCostosRepository _ICentroCostosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCentroCostosQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICentroCostosRepository ICentroCostosRepository,
            IMapper mapper)
        {
            _ICentroCostosRepository = ICentroCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerCentroCostosResponseViewModel> Handle(ObtenerCentroCostosViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = CentroCostosMap.MaptoDTO(request);
            var _result = await _ICentroCostosRepository.ObtenerCentroCostos(dto);


            if (request.idCentroCostos == 0) throw new MreException("ingrese idCentroCostos");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCentroCostosResponseViewModel>(_result);
        }
    }
}
