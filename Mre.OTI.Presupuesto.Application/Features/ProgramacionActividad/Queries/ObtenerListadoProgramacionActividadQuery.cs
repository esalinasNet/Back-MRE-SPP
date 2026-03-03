using AutoMapper;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Queries;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionActividad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using System.Linq;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Util;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionActividad.Queries
{
    public class ObtenerListadoProgramacionActividadQuery : IRequestHandler<ObtenerListadoProgramacionActividadViewModel, IEnumerable<ObtenerListadoProgramacionActividadResponseViewModel>>
    {
        private readonly IProgramacionActividadRepository _IProgramacionActividadRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoProgramacionActividadQuery(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionActividadRepository IProgramacionActividadRepository, IMapper mapper)
        {
            _IProgramacionActividadRepository = IProgramacionActividadRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionActividadResponseViewModel>> Handle(ObtenerListadoProgramacionActividadViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = ProgramacionActividadMap.MaptoProgramacionActividadDTO(request);

                var result = await _IProgramacionActividadRepository.ObtenerListadoProgramacionActividad(dto);

                return result.Select(x => (ObtenerListadoProgramacionActividadResponseViewModel)ProgramacionActividadMap.MaptoViewModel(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
