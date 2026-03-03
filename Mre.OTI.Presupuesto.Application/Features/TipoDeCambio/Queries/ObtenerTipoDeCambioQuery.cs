using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.TipoDeCambio;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.TipoDeCambio.Queries
{
    internal class ObtenerTipoDeCambioQuery : IRequestHandler<ObtenerTipoDeCambioViewModel, ObtenerTipoDeCambioResponseViewModel>
    {
        readonly private ITipoDeCambioRepository _ITipoDeCambioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerTipoDeCambioQuery(IUsuarioRolRepository IIUsuarioRolRepository, ITipoDeCambioRepository ITipoDeCambioRepository, IMapper mapper)
        {
            _ITipoDeCambioRepository = ITipoDeCambioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerTipoDeCambioResponseViewModel> Handle(ObtenerTipoDeCambioViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = TipoDeCambioMap.MaptoDTO(request);
            var _result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(dto);
                        

            if (request.idMoneda == 0) throw new MreException("ingrese idMoneda");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerTipoDeCambioResponseViewModel>(_result);
        }
    }
}
