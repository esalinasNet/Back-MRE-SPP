using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.EspecificaGasto;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.EspecificaGasto.Queries
{
    public class ObtenerEspecificaGastoPaginadoQuery : IRequestHandler<ObtenerEspecificaGastoPaginadoViewModel, dtEspecificaGastoPaginadoResponseViewModel>
    {
        private readonly IEspecificaGastoRepository _IEspecificaGastoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerEspecificaGastoPaginadoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IEspecificaGastoRepository IEspecificaGastoRepository,
            IMapper mapper)
        {
            _IEspecificaGastoRepository = IEspecificaGastoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtEspecificaGastoPaginadoResponseViewModel> Handle(ObtenerEspecificaGastoPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = EspecificaGastoMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IEspecificaGastoRepository.ObtenerEspecificaGastoPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerEspecificaGastoPaginadoResponseViewModel>>(result);

            dtEspecificaGastoPaginadoResponseViewModel data = new dtEspecificaGastoPaginadoResponseViewModel
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
