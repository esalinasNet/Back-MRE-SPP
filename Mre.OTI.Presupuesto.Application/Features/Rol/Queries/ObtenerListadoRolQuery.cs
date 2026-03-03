using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Rol;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Rol.Queries
{
    public class ObtenerListadoRolQuery : IRequestHandler<ObtenerListadoRolViewModel, IEnumerable<ObtenerListadoRolResponseViewModel>>
    {
        readonly private IRolRepository _IRolRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoRolQuery(IUsuarioRolRepository IIUsuarioRolRepository, IRolRepository IRolRepository, IMapper mapper)
        {
            _IRolRepository = IRolRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<IEnumerable<ObtenerListadoRolResponseViewModel>> Handle(ObtenerListadoRolViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = RolMap.MaptoDTO(request);

                var result = await _IRolRepository.ObtenerListadoRol(dto);

                return result.Select(x => (ObtenerListadoRolResponseViewModel)RolMap.MaptoViewModel(x));

                // return _mapper.Map<ObtenerListadoRolResponseViewModel>(result);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
