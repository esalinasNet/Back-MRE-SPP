using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.AprobacionesCostos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.AprobacionesCostos.Queries
{    
    public class ObtenerAprobacionesCostosPaginadoQuery : IRequestHandler<ObtenerAprobacionesCostosPaginadoViewModel, dtAprobacionesCostosPaginadoResponseViewModel>
    {
        readonly private IAprobacionesCostosRepository _IAprobacionesCostosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerAprobacionesCostosPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAprobacionesCostosRepository IAprobacionesCostosRepository, IMapper mapper)
        {
            _IAprobacionesCostosRepository = IAprobacionesCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtAprobacionesCostosPaginadoResponseViewModel> Handle(ObtenerAprobacionesCostosPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = AprobacionesCostosMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IAprobacionesCostosRepository.ObtenerAprobacionesCostosPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerAprobacionesCostosPaginadoResponseViewModel>>(result);

            dtAprobacionesCostosPaginadoResponseViewModel data = new dtAprobacionesCostosPaginadoResponseViewModel
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
