using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Queries
{
    public class ObtenerCodigoProgramacionTareasQuery : IRequestHandler<ObtenerCodigoProgramacionTareasViewModel, ObtenerCodigoProgramacionTareasResponseViewModel>
    {
        private readonly IProgramacionTareasRepository _IProgramacionTareasRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCodigoProgramacionTareasQuery(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionTareasRepository IProgramacionTareasRepository, IMapper mapper)
        {
            _IProgramacionTareasRepository = IProgramacionTareasRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerCodigoProgramacionTareasResponseViewModel> Handle(ObtenerCodigoProgramacionTareasViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = ProgramacionTareasMap.MaptoDTOCodigoProgramacionTareas(request);

            var _result = await _IProgramacionTareasRepository.ObtenerCodigoProgramacionTareas(dto);

            if (request.codigoTareas == "") throw new MreException("ingrese codigoTareas");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerCodigoProgramacionTareasResponseViewModel>(_result);
        }
    }
}
