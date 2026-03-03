using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.DivisionFuncional;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.DivisionFuncional.Queries
{
    public class ObtenerDivisionFuncionalPaginadoQuery : IRequestHandler<ObtenerDivisionFuncionalPaginadoViewModel, dtDivisionFuncionalPaginadoResponseViewModel>
    {
        private readonly IDivisionFuncionalRepository _IDivisionFuncionalRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerDivisionFuncionalPaginadoQuery( IUsuarioRolRepository IUsuarioRolRepository, IDivisionFuncionalRepository IDivisionFuncionalRepository, IMapper mapper)
        {
            _IDivisionFuncionalRepository = IDivisionFuncionalRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtDivisionFuncionalPaginadoResponseViewModel> Handle(ObtenerDivisionFuncionalPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = DivisionFuncionalMap.MaptoDTO(request);

            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IDivisionFuncionalRepository.ObtenerDivisionFuncionalPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerDivisionFuncionalPaginadoResponseViewModel>>(result);

            dtDivisionFuncionalPaginadoResponseViewModel data = new dtDivisionFuncionalPaginadoResponseViewModel
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
