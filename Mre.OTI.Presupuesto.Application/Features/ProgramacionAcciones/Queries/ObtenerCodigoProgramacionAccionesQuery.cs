using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionAcciones;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries
{
    public class ObtenerCodigoProgramacionAccionesQuery : IRequestHandler<ObtenerCodigoProgramacionAccionesViewModel, ObtenerCodigoProgramacionAccionesResponseViewModel>
    {
        private readonly IProgramacionAccionesRepository _IProgramacionAccionesRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCodigoProgramacionAccionesQuery(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionAccionesRepository IProgramacionAccionesRepository, IMapper mapper)
        {
            _IProgramacionAccionesRepository = IProgramacionAccionesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerCodigoProgramacionAccionesResponseViewModel> Handle(ObtenerCodigoProgramacionAccionesViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = ProgramacionAccionesMap.MaptoDTOCodigoProgramacionAcciones(request);

            var _result = await _IProgramacionAccionesRepository.ObtenerCodigoProgramacionAcciones(dto);

            if (request.codigoAcciones == "") throw new MreException("ingrese codigoAcciones");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCodigoProgramacionAccionesResponseViewModel>(_result);
        }
    }
}
