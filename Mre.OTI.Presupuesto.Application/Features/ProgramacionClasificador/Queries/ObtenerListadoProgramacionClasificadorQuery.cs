using AutoMapper;
using MediatR;
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
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Queries
{
    public class ObtenerListadoProgramacionClasificadorQuery : IRequestHandler<ObtenerListadoProgramacionClasificadorViewModel, IEnumerable<ObtenerListadoProgramacionClasificadorResponseViewModel>>
    {
        readonly private IProgramacionClasificadorRepository _IProgramacionClasificadorRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoProgramacionClasificadorQuery(IUsuarioRolRepository IIUsuarioRolRepository, IProgramacionClasificadorRepository IProgramacionClasificadorRepository, IMapper mapper)
        {
            _IProgramacionClasificadorRepository = IProgramacionClasificadorRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoProgramacionClasificadorResponseViewModel>> Handle(ObtenerListadoProgramacionClasificadorViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = ProgramacionClasificadorMap.MaptoProgramacionClasificadorDTO(request);

                var result = await _IProgramacionClasificadorRepository.ObtenerListadoProgramacionClasificador(dto);

                return result.Select(x => (ObtenerListadoProgramacionClasificadorResponseViewModel)ProgramacionClasificadorMap.MaptoViewModelProgramacionClasificador(x));

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
