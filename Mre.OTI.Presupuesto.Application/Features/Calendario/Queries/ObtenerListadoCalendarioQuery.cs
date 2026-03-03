using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Features.CentroCostos.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using Mre.OTI.Presupuesto.Application.Responses.CentroCostos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Calendario.Queries
{
    public class ObtenerListadoCalendarioQuery : IRequestHandler<ObtenerListadoCalendarioViewModel, IEnumerable<ObtenerListadoCalendarioResponseViewModel>>
    {
        readonly private ICalendarioRepository _ICalendarioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerListadoCalendarioQuery(IUsuarioRolRepository IIUsuarioRolRepository, ICalendarioRepository ICalendarioRepository, IMapper mapper)
        {
            _ICalendarioRepository = ICalendarioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<IEnumerable<ObtenerListadoCalendarioResponseViewModel>> Handle(ObtenerListadoCalendarioViewModel request, CancellationToken cancellationToken)
        {
            var result = await _ICalendarioRepository.ObtenerListadoCalendario();

            return result.Select(x => (ObtenerListadoCalendarioResponseViewModel)CalendarioMap.MaptoViewModel(x));
        }
    }
}
