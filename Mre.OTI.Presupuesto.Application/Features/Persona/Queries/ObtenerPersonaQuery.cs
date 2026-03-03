using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Persona;
using Mre.OTI.Presupuesto.Application.Util;
using Mre.OTI.Presupuesto.Domain.Setting;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Persona.Queries
{
    public class ObtenerPersonaQuery : IRequestHandler<ObtenerPersonaViewModel, ObtenerPersonaResponseViewModel>
    {
        readonly private IPersonaRepository _IPersonaRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerPersonaQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPersonaRepository IPersonaRepository, IMapper mapper)
        {
            _IPersonaRepository = IPersonaRepository;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
            _mapper = mapper;
        }
        public async Task<ObtenerPersonaResponseViewModel> Handle(ObtenerPersonaViewModel request, CancellationToken cancellationToken)
        {
            //  var dto = CatalogoMap.MaptoDTO(request);
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
            if (request.idPersona == 0) throw new MreException("ingrese idPersona");
            var result = await _IPersonaRepository.ObtenerPersona(request.idPersona);
            
            return _mapper.Map<ObtenerPersonaResponseViewModel>(result);
        }
    }
}
