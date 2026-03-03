using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Viaticos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Viaticos.Queries
{
    public class ObtenerViaticoPaginadoQuery : IRequestHandler<ObtenerViaticoPaginadoViewModel, dtViaticoPaginadoResponseViewModel>
    {
        private readonly IViaticosRepository _IViaticosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerViaticoPaginadoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IViaticosRepository IViaticosRepository,
            IMapper mapper)
        {
            _IViaticosRepository = IViaticosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtViaticoPaginadoResponseViewModel> Handle(ObtenerViaticoPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = ViaticosMap.MaptoPaginadoDTO(request);

            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IViaticosRepository.ObtenerViaticoPaginado(dto);
            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;
            var datos = _mapper.Map<IEnumerable<ObtenerViaticoPaginadoResponseViewModel>>(result);

            dtViaticoPaginadoResponseViewModel data = new dtViaticoPaginadoResponseViewModel
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