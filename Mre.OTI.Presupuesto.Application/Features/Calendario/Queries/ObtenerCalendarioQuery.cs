using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.CentroCostos.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using Mre.OTI.Presupuesto.Application.Responses.CentroCostos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Calendario.Queries
{
    public class ObtenerCalendarioQuery : IRequestHandler<ObtenerCalendarioViewModel, ObtenerCalendarioResponseViewModel>
    {
        readonly private ICalendarioRepository _ICalendarioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerCalendarioQuery(IUsuarioRolRepository IIUsuarioRolRepository, ICalendarioRepository ICalendarioRepository, IMapper mapper)
        {
            _ICalendarioRepository = ICalendarioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<ObtenerCalendarioResponseViewModel> Handle(ObtenerCalendarioViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = CalendarioMap.MaptoDTO(request);
            var _result = await _ICalendarioRepository.ObtenerCalendario(dto);


            if (request.idPeriodo == 0) throw new MreException("ingrese idPeriodo");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCalendarioResponseViewModel>(_result);
        }
    }
}
