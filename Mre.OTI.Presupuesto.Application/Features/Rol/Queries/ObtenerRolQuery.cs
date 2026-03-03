using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Rol;
using Mre.OTI.Presupuesto.Application.Util;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Queries
{
    public class ObtenerRolQuery : IRequestHandler<ObtenerRolViewModel, ObtenerRolResponseViewModel>
    {
        readonly private IRolRepository _IRolRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerRolQuery(IUsuarioRolRepository IIUsuarioRolRepository, IRolRepository IRolRepository, IMapper mapper)
        {
            _IRolRepository = IRolRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<ObtenerRolResponseViewModel> Handle(ObtenerRolViewModel request, CancellationToken cancellationToken)
        {
            //  var dto = CatalogoMap.MaptoDTO(request);
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
            if (request.idRol == 0) throw new MreException("ingrese idRol");
            var result = await _IRolRepository.ObtenerRol(request.idRol);

            return _mapper.Map<ObtenerRolResponseViewModel>(result);
        }
    }
}
