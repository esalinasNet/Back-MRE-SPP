using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Calendario.Queries
{
    public class ObtenerCalendarioPaginadoQuery : IRequestHandler<ObtenerCalendarioPaginadoViewModel, dtCalendarioPaginadoResponseViewModel>
    {
        readonly private ICalendarioRepository _ICalendarioRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerCalendarioPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, ICalendarioRepository ICalendarioRepository, IMapper mapper)
        {
            _ICalendarioRepository = ICalendarioRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtCalendarioPaginadoResponseViewModel> Handle(ObtenerCalendarioPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = CalendarioMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _ICalendarioRepository.ObtenerCalendarioPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerCalendarioPaginadoResponseViewModel>>(result);

            dtCalendarioPaginadoResponseViewModel data = new dtCalendarioPaginadoResponseViewModel
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
