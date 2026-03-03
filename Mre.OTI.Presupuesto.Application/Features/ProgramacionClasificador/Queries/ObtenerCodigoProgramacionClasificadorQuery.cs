using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionClasificador;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Queries
{
    public class ObtenerCodigoProgramacionClasificadorQuery : IRequestHandler<ObtenerCodigoProgramacionClasificadorViewModel, ObtenerCodigoProgramacionClasificadorResponseViewModel>
    {
        private readonly IProgramacionClasificadorRepository _IProgramacionClasificadorRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCodigoProgramacionClasificadorQuery(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionClasificadorRepository IProgramacionClasificadorRepository, IMapper mapper)
        {
            _IProgramacionClasificadorRepository = IProgramacionClasificadorRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerCodigoProgramacionClasificadorResponseViewModel> Handle(ObtenerCodigoProgramacionClasificadorViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = ProgramacionClasificadorMap.MaptoDTOCodigoProgramacionClasificador(request);

            var _result = await _IProgramacionClasificadorRepository.ObtenerCodigoProgramacionClasificador(dto);

            if (request.codigoClasificador == "") throw new MreException("ingrese codigoClasificador");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCodigoProgramacionClasificadorResponseViewModel>(_result);
        }
    }
}
