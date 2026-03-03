using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Usuario.Queries
{
    public class ObtenerListadoUsuarioSelectQuery : IRequestHandler<ObtenerListadoUsuarioSelectViewModel, IEnumerable<ObtenerListadoUsuarioSelectResponseViewModel>>
    {
        readonly private IUsuarioRepository _IUsuarioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoUsuarioSelectQuery(IUsuarioRolRepository IIUsuarioRolRepository, IUsuarioRepository IUsuarioRepository, IMapper mapper)
        {
            _IUsuarioRepository = IUsuarioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoUsuarioSelectResponseViewModel>> Handle(ObtenerListadoUsuarioSelectViewModel request, CancellationToken cancellationToken)
        {
            var result = await _IUsuarioRepository.ObtenerListadoUsuarioSelect();

            return result.Select(x => (ObtenerListadoUsuarioSelectResponseViewModel)UsuarioMap.MaptoViewModelSelect(x));
        }
    }
}
