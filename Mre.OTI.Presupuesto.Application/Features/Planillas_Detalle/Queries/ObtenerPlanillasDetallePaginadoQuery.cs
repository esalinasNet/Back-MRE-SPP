using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Planillas_Detalle;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas_Detalle.Queries
{    
    public class ObtenerPlanillasDetallePaginadoQuery : IRequestHandler<ObtenerPlanillasDetallePaginadoViewModel, dtPlanillasDetallePaginadoResponseViewModel>
    {
        readonly private IPlanillasDetalleRepository _IPlanillasDetalleRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerPlanillasDetallePaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPlanillasDetalleRepository IPlanillasDetalleRepository, IMapper mapper)
        {
            _IPlanillasDetalleRepository = IPlanillasDetalleRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtPlanillasDetallePaginadoResponseViewModel> Handle(ObtenerPlanillasDetallePaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = PlanillasDetalleMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IPlanillasDetalleRepository.ObtenerPlanillasDetallePaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerPlanillasDetallePaginadoResponseViewModel>>(result);

            dtPlanillasDetallePaginadoResponseViewModel data = new dtPlanillasDetallePaginadoResponseViewModel
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
