using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Sistema.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Sistema.Queries
{
    public class ObtenerListadoSistemaQuery : IRequestHandler<ObtenerListadoSistemaViewModel, IEnumerable<ObtenerListadoSistemaResponseViewModel>>
    {
        private readonly ISistemaRepository _ISistemaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoSistemaQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            ISistemaRepository ISistemaRepository,
            IMapper mapper)
        {
            _ISistemaRepository = ISistemaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }
        public async Task<IEnumerable<ObtenerListadoSistemaResponseViewModel>> Handle(ObtenerListadoSistemaViewModel request, CancellationToken cancellationToken)
        {
            var result = await _ISistemaRepository.ObtenerListadoSistema();

            return result.Select(x => (ObtenerListadoSistemaResponseViewModel)SistemaMap.MaptoViewModel(x));
        }
    }
}
