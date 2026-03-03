using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Usuario;
using Mre.OTI.Presupuesto.Application.Util;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Queries
{
    public class ObtenerUsuarioPaginadoQuery : IRequestHandler<ObtenerUsuarioPaginadoViewModel, dtUsuarioPaginadoResponseViewModel>
    {
        readonly private IUsuarioRepository _IUsuarioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerUsuarioPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IUsuarioRepository IUsuarioRepository, IMapper mapper)
        {
            _IUsuarioRepository = IUsuarioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<dtUsuarioPaginadoResponseViewModel> Handle(ObtenerUsuarioPaginadoViewModel request, CancellationToken cancellationToken)
        {
            await ValidateGlobalBase.Autorizacion(request.usuarioConsulta, _IUsuarioRolRepository, new List<VariablesGlobales.TablaRol> {
                   VariablesGlobales.TablaRol.ANALISTA_OGTH
               });
            var dto = UsuarioMap.MaptoDTO(request);
            dto.fraseEncriptacion=Constantes.SISTEMA.KEY_ENCRYPT_LOGIN;
            if (request.paginaActual == 0) throw new MreException("ingrese paginaActual");
            if (request.tamanioPagina == 0) throw new MreException("tamanioPagina anio");

            var result = await _IUsuarioRepository.ObtenerUsuarioPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerUsuarioPaginadoResponseViewModel>>(result);

            dtUsuarioPaginadoResponseViewModel data = new dtUsuarioPaginadoResponseViewModel
            {
                draw = request.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsTotal,
                data = datos
            };

            return data;
        }
    }
}
