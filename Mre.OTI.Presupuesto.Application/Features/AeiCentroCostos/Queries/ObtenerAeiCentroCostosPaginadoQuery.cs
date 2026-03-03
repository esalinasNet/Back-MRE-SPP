using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.AeiCentroCostos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.AeiCentroCostos.Queries
{
    public class ObtenerAeiCentroCostosPaginadoQuery : IRequestHandler<ObtenerAeiCentroCostosPaginadoViewModel, dtAeiCentroCostosPaginadoResponseViewModel>
    {
        readonly private IAeiCentroCostosRepository _IAeiCentroCostosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerAeiCentroCostosPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAeiCentroCostosRepository IAeiCentroCostosRepository, IMapper mapper)
        {
            _IAeiCentroCostosRepository = IAeiCentroCostosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtAeiCentroCostosPaginadoResponseViewModel> Handle(ObtenerAeiCentroCostosPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = AeiCentroCostosMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IAeiCentroCostosRepository.ObtenerAeiCentroCostosPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerAeiCentroCostosPaginadoResponseViewModel>>(result);

            dtAeiCentroCostosPaginadoResponseViewModel data = new dtAeiCentroCostosPaginadoResponseViewModel
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
