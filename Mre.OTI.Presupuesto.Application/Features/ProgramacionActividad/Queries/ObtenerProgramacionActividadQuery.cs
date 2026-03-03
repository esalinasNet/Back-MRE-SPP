using AutoMapper;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionActividad;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Queries
{
    public class ObtenerProgramacionActividadQuery : IRequestHandler<ObtenerProgramacionActividadViewModel, ObtenerProgramacionActividadResponseViewModel>
    {
        private readonly IProgramacionActividadRepository _IProgramacionActividadRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerProgramacionActividadQuery(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionActividadRepository IProgramacionActividadRepository, IMapper mapper)
        {
            _IProgramacionActividadRepository = IProgramacionActividadRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<ObtenerProgramacionActividadResponseViewModel> Handle(ObtenerProgramacionActividadViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

            var dto = ProgramacionActividadMap.MaptoDTO(request);

            var _result = await _IProgramacionActividadRepository.ObtenerProgramacionActividad(dto);

            if (request.idProgramacionActividad == 0) throw new MreException("ingrese idProgramacionActividad");

            //var result = await _ITipoDeCambioRepository.ObtenerTipoDeCambio(request.idMoneda);

            return _mapper.Map<ObtenerProgramacionActividadResponseViewModel>(_result);
        }
    }
}
