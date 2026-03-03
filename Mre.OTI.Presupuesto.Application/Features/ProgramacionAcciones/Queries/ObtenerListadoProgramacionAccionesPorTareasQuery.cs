using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionAcciones;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries
{
    public class ObtenerListadoProgramacionAccionesPorTareasQuery : IRequestHandler<ObtenerListadoProgramacionAccionesPorTareasViewModel, IEnumerable<ObtenerListadoProgramacionAccionesResponseViewModel>>
    {
        readonly private IProgramacionAccionesRepository _IProgramacionAccionesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoProgramacionAccionesPorTareasQuery(IUsuarioRolRepository IIUsuarioRolRepository, IProgramacionAccionesRepository IProgramacionAccionesRepository, IMapper mapper)
        {
            _IProgramacionAccionesRepository = IProgramacionAccionesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionAccionesResponseViewModel>> Handle(ObtenerListadoProgramacionAccionesPorTareasViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = ProgramacionAccionesMap.MaptoProgramacionAccionesPorTareasDTO(request);

                var result = await _IProgramacionAccionesRepository.ObtenerListadoProgramacionAccionesPorTareas(dto);

                return result.Select(x => (ObtenerListadoProgramacionAccionesResponseViewModel)ProgramacionAccionesMap.MaptoViewModelProgramacionAcciones(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
