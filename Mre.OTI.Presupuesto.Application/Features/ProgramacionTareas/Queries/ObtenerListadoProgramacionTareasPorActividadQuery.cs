using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionTareas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionTareas.Queries
{
    public class ObtenerListadoProgramacionTareasPorActividadQuery : IRequestHandler<ObtenerListadoProgramacionTareasPorActividadViewModel, IEnumerable<ObtenerListadoProgramacionTareasResponseViewModel>>
    {
        readonly private IProgramacionTareasRepository _IProgramacionTareasRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoProgramacionTareasPorActividadQuery(IUsuarioRolRepository IIUsuarioRolRepository, IProgramacionTareasRepository IProgramacionTareasRepository, IMapper mapper)
        {
            _IProgramacionTareasRepository = IProgramacionTareasRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionTareasResponseViewModel>> Handle(ObtenerListadoProgramacionTareasPorActividadViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = ProgramacionTareasMap.MaptoProgramacionTareasPorActividadDTO(request);

                var result = await _IProgramacionTareasRepository.ObtenerListadoProgramacionTareasPorActividad(dto);

                return result.Select(x => (ObtenerListadoProgramacionTareasResponseViewModel)ProgramacionTareasMap.MaptoViewModelProgramacionTareas(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
