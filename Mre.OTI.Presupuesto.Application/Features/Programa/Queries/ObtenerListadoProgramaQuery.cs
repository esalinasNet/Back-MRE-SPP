using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Programa;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionAcciones;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Programa.Queries
{
    public class ObtenerListadoProgramaQuery : IRequestHandler<ObtenerListadoProgramaViewModel, IEnumerable<ObtenerListadoProgramaResponseViewModel>>
    {
        private readonly IProgramaRepository _IProgramaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoProgramaQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IProgramaRepository IProgramaRepository,
            IMapper mapper)
        {
            _IProgramaRepository = IProgramaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<IEnumerable<ObtenerListadoProgramaResponseViewModel>> Handle(ObtenerListadoProgramaViewModel request, CancellationToken cancellationToken)
        {            

            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = ProgramaMap.MaptoProgramaDTO(request);

                var result = await _IProgramaRepository.ObtenerListadoPrograma(dto);

                return result.Select(x => (ObtenerListadoProgramaResponseViewModel)ProgramaMap.MaptoViewModel(x));                

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
