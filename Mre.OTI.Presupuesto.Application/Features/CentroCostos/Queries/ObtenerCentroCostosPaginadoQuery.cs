using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Calendario.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using Mre.OTI.Presupuesto.Application.Responses.CentroCostos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CentroCostos.Queries
{
    public class ObtenerCentroCostosPaginadoQuery : IRequestHandler<ObtenerCentroCostosPaginadoViewModel, dtCentroCostosPaginadoResponseViewModel>
    {
        private readonly ICentroCostosRepository _ICentroCostosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCentroCostosPaginadoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICentroCostosRepository ICentroCostosRepository,
            IMapper mapper)
        {
            _ICentroCostosRepository = ICentroCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtCentroCostosPaginadoResponseViewModel> Handle(ObtenerCentroCostosPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = CentroCostosMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _ICentroCostosRepository.ObtenerCentroCostosPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerCentroCostosPaginadoResponseViewModel>>(result);

            dtCentroCostosPaginadoResponseViewModel data = new dtCentroCostosPaginadoResponseViewModel
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
