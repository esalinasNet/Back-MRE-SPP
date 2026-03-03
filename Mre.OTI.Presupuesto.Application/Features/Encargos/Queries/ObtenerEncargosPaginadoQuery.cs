using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Encargos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Encargos.Queries
{
    public class ObtenerEncargosPaginadoQuery : IRequestHandler<ObtenerEncargosPaginadoViewModel, dtEncargosPaginadoResponseViewModel>
    {
        private readonly IEncargosRepository _IEncargosRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerEncargosPaginadoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IEncargosRepository IEncargosRepository,
            IMapper mapper)
        {
            _IEncargosRepository = IEncargosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtEncargosPaginadoResponseViewModel> Handle(ObtenerEncargosPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = EncargosMap.MaptoPaginadoDTO(request);

            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IEncargosRepository.ObtenerEncargosPaginado(dto);
            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;
            var datos = _mapper.Map<IEnumerable<ObtenerEncargosPaginadoResponseViewModel>>(result);

            dtEncargosPaginadoResponseViewModel data = new dtEncargosPaginadoResponseViewModel
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