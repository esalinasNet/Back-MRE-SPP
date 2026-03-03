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
    public class ObtenerProgramacionActividadClasificadorQuery : IRequestHandler<ObtenerProgramacionActividadClasificadorViewModel, ObtenerProgramacionActividadClasificadorResponseViewModel>
    {
        private readonly IProgramacionClasificadorRepository _IProgramacionClasificadorRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerProgramacionActividadClasificadorQuery(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionClasificadorRepository IProgramacionClasificadorRepository, IMapper mapper)
        {
            _IProgramacionClasificadorRepository = IProgramacionClasificadorRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerProgramacionActividadClasificadorResponseViewModel> Handle(ObtenerProgramacionActividadClasificadorViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = ProgramacionClasificadorMap.MaptoActividadClasificadorDTO(request);

            var _result = await _IProgramacionClasificadorRepository.ObtenerProgramacionActividadClasificador(dto);

            if (request.idProgramacionActividad == 0) throw new MreException("ingrese idProgramacionActividad");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerProgramacionActividadClasificadorResponseViewModel>(_result);
        }
    }
}
