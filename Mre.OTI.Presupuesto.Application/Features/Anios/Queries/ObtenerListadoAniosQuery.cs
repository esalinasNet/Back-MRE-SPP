using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.Anios.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Anios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Anios.Queries
{
    public class ObtenerListadoAniosQuery : IRequestHandler<ObtenerListadoAniosViewModel, IEnumerable<ObtenerListadoAniosResponseViewModel>>
    {
        private readonly IAniosRepository _IAniosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerListadoAniosQuery(
           IUsuarioRolRepository IUsuarioRolRepository,
           IAniosRepository IAniosRepository,
           IMapper mapper)
        {
            _IAniosRepository = IAniosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoAniosResponseViewModel>> Handle(ObtenerListadoAniosViewModel request, CancellationToken cancellationToken)
        {
            var result = await _IAniosRepository.ObtenerListadoAnios();

            return result.Select(x => (ObtenerListadoAniosResponseViewModel)AniosMap.MaptoViewModel(x));
        }
    }
}
