using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.OtrosGastos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.OtrosGastos.Queries
{
    public class ObtenerOtrosGastosPaginadoQuery : IRequestHandler<ObtenerOtrosGastosPaginadoViewModel, dtOtrosGastosPaginadoResponseViewModel>
    {
        private readonly IOtrosGastosRepository _IOtrosGastosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerOtrosGastosPaginadoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IOtrosGastosRepository IOtrosGastosRepository,
            IMapper mapper)
        {
            _IOtrosGastosRepository = IOtrosGastosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtOtrosGastosPaginadoResponseViewModel> Handle(ObtenerOtrosGastosPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = OtrosGastosMap.MaptoPaginadoDTO(request);

            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IOtrosGastosRepository.ObtenerOtrosGastosPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;
            var datos = _mapper.Map<IEnumerable<ObtenerOtrosGastosPaginadoResponseViewModel>>(result);

            dtOtrosGastosPaginadoResponseViewModel data = new dtOtrosGastosPaginadoResponseViewModel
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