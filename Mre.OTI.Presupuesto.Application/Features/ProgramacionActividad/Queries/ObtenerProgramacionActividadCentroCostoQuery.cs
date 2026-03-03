using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionActividad;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Queries
{
    public class ObtenerProgramacionActividadCentroCostoQuery  : IRequestHandler<ObtenerProgramacionActividadCentroCostosViewModel, IEnumerable<ObtenerProgramacionActividadCentroCostosResponseViewModel>>
    {
        private readonly IProgramacionActividadRepository _IProgramacionActividadRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerProgramacionActividadCentroCostoQuery(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionActividadRepository IProgramacionActividadRepository, IMapper mapper)
        {
            _IProgramacionActividadRepository = IProgramacionActividadRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerProgramacionActividadCentroCostosResponseViewModel>> Handle(ObtenerProgramacionActividadCentroCostosViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
               VariablesGlobales.TablaRol.ANALISTA_OGTH
           });

                var dto = ProgramacionActividadMap.MaptoProgramacionActividadCentroCostoDTO(request);

                var result = await _IProgramacionActividadRepository.ObtenerProgramacionActividadCentroCostos(dto);

                return result.Select(x => (ObtenerProgramacionActividadCentroCostosResponseViewModel)ProgramacionActividadMap.MaptoCentroCostosViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
