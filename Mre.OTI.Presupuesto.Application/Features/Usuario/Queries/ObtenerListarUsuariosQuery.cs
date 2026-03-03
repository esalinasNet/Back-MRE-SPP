using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Usuario;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Mre.OTI.Presupuesto.Application.Mapper;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Queries
{    
    public class ObtenerListarUsuariosQuery : IRequestHandler<ObtenerListarUsuariosViewModel, IEnumerable<ObtenerListarUsuariosResponseViewModel>>
    {
        readonly private IUsuarioRepository _IUsuarioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListarUsuariosQuery(IUsuarioRolRepository IIUsuarioRolRepository, IUsuarioRepository IUsuarioRepository, IMapper mapper)
        {
            _IUsuarioRepository = IUsuarioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListarUsuariosResponseViewModel>> Handle(ObtenerListarUsuariosViewModel request, CancellationToken cancellationToken)
        {
            var result = await _IUsuarioRepository.ObtenerListarUsuarios();

            return result.Select(x => (ObtenerListarUsuariosResponseViewModel)UsuarioMap.MaptoListarUsuarioViewModel(x));
        }
    }


}
