using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Recurso.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Recurso;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Recurso.Queries
{
    public class ObtenerRecursoPaginadoQuery : IRequestHandler<ObtenerRecursoPaginadoViewModel, dtRecursoPaginadoResponseViewModel>
    {
        private readonly IRecursoRepository _IRecursoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerRecursoPaginadoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IRecursoRepository IRecursoRepository,
            IMapper mapper)
        {
            _IRecursoRepository = IRecursoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtRecursoPaginadoResponseViewModel> Handle(ObtenerRecursoPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = RecursoMap.MaptoPaginadoDTO(request);

            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IRecursoRepository.ObtenerRecursoPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;
            var datos = _mapper.Map<IEnumerable<ObtenerRecursoPaginadoResponseViewModel>>(result);

            dtRecursoPaginadoResponseViewModel data = new dtRecursoPaginadoResponseViewModel
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