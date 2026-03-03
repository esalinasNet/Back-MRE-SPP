using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Componente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Componente.Queries
{
    public class ObtenerListadoComponenteQuery : IRequestHandler<ObtenerListadoComponenteViewModel, IEnumerable<ObtenerListadoComponenteResponseViewModel>>
    {
        private readonly IComponenteRepository _IComponenteRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoComponenteQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IComponenteRepository IComponenteRepository,
            IMapper mapper)
        {
            _IComponenteRepository = IComponenteRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<IEnumerable<ObtenerListadoComponenteResponseViewModel>> Handle(ObtenerListadoComponenteViewModel request, CancellationToken cancellationToken)
        {
            var result = await _IComponenteRepository.ObtenerListadoComponente();

            return result.Select(x => (ObtenerListadoComponenteResponseViewModel)ComponenteMap.MaptoViewModel(x));
        }
    }
}
