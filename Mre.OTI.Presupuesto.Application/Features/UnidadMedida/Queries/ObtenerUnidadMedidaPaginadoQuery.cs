using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.UnidadMedida;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.UnidadMedida.Queries
{
    public class ObtenerUnidadMedidaPaginadoQuery : IRequestHandler<ObtenerUnidadMedidaPaginadoViewModel, dtUnidadMedidaPaginadoResponseViewModel>
    {
        private readonly IUnidadMedidaRepository _IUnidadMedidaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerUnidadMedidaPaginadoQuery(IUsuarioRolRepository IUsuarioRolRepository, IUnidadMedidaRepository IUnidadMedidaRepository, IMapper mapper)
        {
            _IUnidadMedidaRepository = IUnidadMedidaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtUnidadMedidaPaginadoResponseViewModel> Handle(ObtenerUnidadMedidaPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = UnidadMedidaMap.MaptoDTO(request);

            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IUnidadMedidaRepository.ObtenerUnidadMedidaPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerUnidadMedidaPaginadoResponseViewModel>>(result);

            dtUnidadMedidaPaginadoResponseViewModel data = new dtUnidadMedidaPaginadoResponseViewModel
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

