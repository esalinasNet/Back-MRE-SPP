using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.CajaChica;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.CajaChica.Queries
{
    public class ObtenerCajaChicaPaginadoQuery : IRequestHandler<ObtenerCajaChicaPaginadoViewModel, dtCajaChicaPaginadoResponseViewModel>
    {
        private readonly ICajaChicaRepository _ICajaChicaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerCajaChicaPaginadoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            ICajaChicaRepository ICajaChicaRepository,
            IMapper mapper)
        {
            _ICajaChicaRepository = ICajaChicaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtCajaChicaPaginadoResponseViewModel> Handle(ObtenerCajaChicaPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = CajaChicaMap.MaptoPaginadoDTO(request);

            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _ICajaChicaRepository.ObtenerCajaChicaPaginado(dto);
            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;
            var datos = _mapper.Map<IEnumerable<ObtenerCajaChicaPaginadoResponseViewModel>>(result);

            dtCajaChicaPaginadoResponseViewModel data = new dtCajaChicaPaginadoResponseViewModel
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