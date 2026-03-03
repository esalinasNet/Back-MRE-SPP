using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Actividad.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Actividad;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Actividad.Queries
{
    public class ObtenerActividadPaginadoQuery : IRequestHandler<ObtenerActividadPaginadoViewModel, dtActividadPaginadoResponseViewModel>
    {
        readonly private IActividadRepository _IActividadRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerActividadPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IActividadRepository IActividadRepository, IMapper mapper)
        {
            _IActividadRepository = IActividadRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtActividadPaginadoResponseViewModel> Handle(ObtenerActividadPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = ActividadMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IActividadRepository.ObtenerActividadPaginado(dto);


            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerActividadPaginadoResponseViewModel>>(result);

            dtActividadPaginadoResponseViewModel data = new dtActividadPaginadoResponseViewModel
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
