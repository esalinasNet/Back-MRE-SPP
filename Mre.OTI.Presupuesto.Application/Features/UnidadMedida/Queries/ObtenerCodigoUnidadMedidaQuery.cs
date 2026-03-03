using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.UnidadMedida;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Queries
{
    public class ObtenerCodigoUnidadMedidaQuery : IRequestHandler<ObtenerCodigoUnidadMedidaViewModel, ObtenerCodigoUnidadMedidaResponseViewModel>
    {
        private readonly IUnidadMedidaRepository _IUnidadMedidaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCodigoUnidadMedidaQuery(IUsuarioRolRepository IUsuarioRolRepository, IUnidadMedidaRepository IUnidadMedidaRepository, IMapper mapper)
        {
            _IUnidadMedidaRepository = IUnidadMedidaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerCodigoUnidadMedidaResponseViewModel> Handle(ObtenerCodigoUnidadMedidaViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = UnidadMedidaMap.MaptoDTOCodigoGrupo(request);

            var _result = await _IUnidadMedidaRepository.ObtenerCodigoUnidadMedida(dto);

            if (request.unidadMedida == "") throw new MreException("ingrese unidadMedida");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCodigoUnidadMedidaResponseViewModel>(_result);
        }
    }
}
