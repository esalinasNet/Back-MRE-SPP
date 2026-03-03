using AutoMapper;
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
using MediatR;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionAcciones.Queries
{
    public class ObtenerListadoProgramacionAccionesQuery : IRequestHandler<ObtenerListadoProgramacionAccionesViewModel, IEnumerable<ObtenerListadoProgramacionAccionesResponseViewModel>>
    {
        readonly private IProgramacionAccionesRepository _IProgramacionAccionesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoProgramacionAccionesQuery(IUsuarioRolRepository IIUsuarioRolRepository, IProgramacionAccionesRepository IProgramacionAccionesRepository, IMapper mapper)
        {
            _IProgramacionAccionesRepository = IProgramacionAccionesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionAccionesResponseViewModel>> Handle(ObtenerListadoProgramacionAccionesViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = ProgramacionAccionesMap.MaptoProgramacionAccionesDTO(request);

                var result = await _IProgramacionAccionesRepository.ObtenerListadoProgramacionAcciones(dto);

                return result.Select(x => (ObtenerListadoProgramacionAccionesResponseViewModel)ProgramacionAccionesMap.MaptoViewModelProgramacionAcciones(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
