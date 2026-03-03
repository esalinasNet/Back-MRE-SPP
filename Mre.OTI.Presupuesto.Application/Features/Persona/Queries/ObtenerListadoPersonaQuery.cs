using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Persona;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Persona.Queries
{
    public class ObtenerListadoPersonaQuery : IRequestHandler<ObtenerListadoPersonaViewModel, IEnumerable<ObtenerListadoPersonaResponseViewModel>>
    {
        readonly private IPersonaRepository _IPersonaRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoPersonaQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPersonaRepository IPersonaRepository, IMapper mapper)
        {
            _IPersonaRepository = IPersonaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<IEnumerable<ObtenerListadoPersonaResponseViewModel>> Handle(ObtenerListadoPersonaViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH,
                   VariablesGlobales.TablaRol.AUXILIAR_OGTH,
                   VariablesGlobales.TablaRol.PERSONAL
               });
                var result = await _IPersonaRepository.ObtenerListadoPersona();
                return result.Select(x => (ObtenerListadoPersonaResponseViewModel)PersonaMap.MaptoViewModel(x));

                // return _mapper.Map<ObtenerListadoPersonaResponseViewModel>(result);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
