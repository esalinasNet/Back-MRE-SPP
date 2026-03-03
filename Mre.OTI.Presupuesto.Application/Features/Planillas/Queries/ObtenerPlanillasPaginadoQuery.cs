using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Planillas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.Planillas.Queries
{    
    public class ObtenerPlanillasPaginadoQuery : IRequestHandler<ObtenerPlanillasPaginadoViewModel, dtPlanillasPaginadoResponseViewModel>
    {
        readonly private IPlanillasRepository _IPlanillasRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerPlanillasPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPlanillasRepository IPlanillasRepository, IMapper mapper)
        {
            _IPlanillasRepository = IPlanillasRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtPlanillasPaginadoResponseViewModel> Handle(ObtenerPlanillasPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = PlanillasMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IPlanillasRepository.ObtenerPlanillasPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerPlanillasPaginadoResponseViewModel>>(result);

            dtPlanillasPaginadoResponseViewModel data = new dtPlanillasPaginadoResponseViewModel
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
