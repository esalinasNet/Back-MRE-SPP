using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Usuario;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Queries
{
    public class ObtenerListadoUsuarioQuery : IRequestHandler<ObtenerListadoUsuarioViewModel, IEnumerable<ObtenerListadoUsuarioResponseViewModel>>
    {
        readonly private IUsuarioRepository _IUsuarioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoUsuarioQuery(IUsuarioRolRepository IIUsuarioRolRepository, IUsuarioRepository IUsuarioRepository, IMapper mapper)
        {
            _IUsuarioRepository = IUsuarioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<IEnumerable<ObtenerListadoUsuarioResponseViewModel>> Handle(ObtenerListadoUsuarioViewModel request, CancellationToken cancellationToken)
        {
            try
            {
                await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });

                var dto = UsuarioMap.MaptoDTO(request);

                var result = await _IUsuarioRepository.ObtenerListadoUsuario(dto);
                return result.Select(x => (ObtenerListadoUsuarioResponseViewModel)UsuarioMap.MaptoViewModel(x));

                // return _mapper.Map<ObtenerListadoUsuarioResponseViewModel>(result);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
