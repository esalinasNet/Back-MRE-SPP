using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Planilla;
using Mre.OTI.Presupuesto.Application.Responses.Planillas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Planilla.Queries
{
    public class ObtenerPlanillaPaginadoQuery : IRequestHandler<ObtenerPlanillaPaginadoViewModel, dtPlanillaPaginadoResponseViewModel>
    {
        private readonly IPlanillaRepository _IPlanillaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerPlanillaPaginadoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IPlanillaRepository IPlanillaRepository,
            IMapper mapper)
        {
            _IPlanillaRepository = IPlanillaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtPlanillaPaginadoResponseViewModel> Handle(ObtenerPlanillaPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = PlanillaMap.MaptoPaginadoDTO(request);

            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IPlanillaRepository.ObtenerPlanillaPaginado(dto);
            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;
            var datos = _mapper.Map<IEnumerable<ObtenerPlanillaPaginadoResponseViewModel>>(result);

            dtPlanillaPaginadoResponseViewModel data = new dtPlanillaPaginadoResponseViewModel
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