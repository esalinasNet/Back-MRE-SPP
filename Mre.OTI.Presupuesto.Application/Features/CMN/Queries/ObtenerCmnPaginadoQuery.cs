using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Cmn;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Cmn.Queries
{
    public class ObtenerCmnPaginadoQuery : IRequestHandler<ObtenerCmnPaginadoViewModel, dtCmnPaginadoResponseViewModel>
    {
        private readonly ICmnRepository _ICmnRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCmnPaginadoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICmnRepository ICmnRepository,
            IMapper mapper)
        {
            _ICmnRepository = ICmnRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtCmnPaginadoResponseViewModel> Handle(ObtenerCmnPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = CmnMap.MaptoPaginadoDTO(request);

            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _ICmnRepository.ObtenerCmnPaginado(dto);
            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;
            var datos = _mapper.Map<IEnumerable<ObtenerCmnPaginadoResponseViewModel>>(result);

            dtCmnPaginadoResponseViewModel data = new dtCmnPaginadoResponseViewModel
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