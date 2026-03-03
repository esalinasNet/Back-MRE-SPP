using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionActividad;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Queries
{
    public class ObtenerProgramacionActividadAniosQuery : IRequestHandler<ObtenerProgramacionActividadAniosViewModel, ObtenerProgramacionActividadAniosResponseViewModel>
    {
        private readonly IProgramacionActividadRepository _IProgramacionActividadRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerProgramacionActividadAniosQuery(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionActividadRepository IProgramacionActividadRepository, IMapper mapper)
        {
            _IProgramacionActividadRepository = IProgramacionActividadRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerProgramacionActividadAniosResponseViewModel> Handle(ObtenerProgramacionActividadAniosViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = ProgramacionActividadMap.MaptoActividadAniosDTO(request);

            var _result = await _IProgramacionActividadRepository.ObtenerProgramacionActividadAnios(dto);

            if (request.idAnio == 0) throw new MreException("ingrese idAnio");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerProgramacionActividadAniosResponseViewModel>(_result);
        }
    }
}
