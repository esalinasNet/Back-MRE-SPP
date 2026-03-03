using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos_Detalle;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos_Detalle.Queries
{    
    public class ObtenerAprobacionesCostosDetallePaginadoQuery : IRequestHandler<ObtenerAprobacionesCostosDetallePaginadoViewModel, dtAprobacionesCostosDetallePaginadoResponseViewModel>
    {
        readonly private IAprobacionesCostosDetalleRepository _IAprobacionesCostosDetalleRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerAprobacionesCostosDetallePaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAprobacionesCostosDetalleRepository IAprobacionesCostosDetalleRepository, IMapper mapper)
        {
            _IAprobacionesCostosDetalleRepository = IAprobacionesCostosDetalleRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtAprobacionesCostosDetallePaginadoResponseViewModel> Handle(ObtenerAprobacionesCostosDetallePaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = AprobacionesCostosDetalleMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IAprobacionesCostosDetalleRepository.ObtenerAprobacionesCostosDetallePaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerAprobacionesCostosDetallePaginadoResponseViewModel>>(result);

            dtAprobacionesCostosDetallePaginadoResponseViewModel data = new dtAprobacionesCostosDetallePaginadoResponseViewModel
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
