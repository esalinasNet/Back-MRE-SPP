using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Paises.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Paises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Paises.Queries
{
    public class ObtenerListadoPaisesQuery : IRequestHandler<ObtenerListadoPaisesViewModel, IEnumerable<ObtenerListadoPaisesResponseViewModel>>
    {
        private readonly IPaisesRepository _IPaisesRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoPaisesQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IPaisesRepository IPaisesRepository,
            IMapper mapper)
        {
            _IPaisesRepository = IPaisesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<IEnumerable<ObtenerListadoPaisesResponseViewModel>> Handle(ObtenerListadoPaisesViewModel request, CancellationToken cancellationToken)
        {
            var result = await _IPaisesRepository.ObtenerListadoPaises();

            return result.Select(x => (ObtenerListadoPaisesResponseViewModel)PaisesMap.MaptoViewModel(x));
        }
    }
}
