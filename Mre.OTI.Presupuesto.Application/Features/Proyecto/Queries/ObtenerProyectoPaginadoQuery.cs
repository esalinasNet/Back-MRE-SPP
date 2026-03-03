using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProductoProyecto;
using Mre.OTI.Presupuesto.Application.Responses.Proyecto;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Proyecto.Queries
{
    public class ObtenerProyectoPaginadoQuery : IRequestHandler<ObtenerProyectoPaginadoViewModel, dtProyectoPaginadoResponseViewModel>
    {
        private readonly IProyectoRepository _IProyectoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioRolRepository _IUsuarioRolRepository;

        public ObtenerProyectoPaginadoQuery(
            IUsuarioRolRepository IUsuarioRolRepository,
            IProyectoRepository IProyectoRepository,
            IMapper mapper)
        {
            _IProyectoRepository = IProyectoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IUsuarioRolRepository;
        }

        public async Task<dtProyectoPaginadoResponseViewModel> Handle(ObtenerProyectoPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = ProyectoMap.MaptoPaginadoDTO(request);

            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IProyectoRepository.ObtenerProyectoPaginado(dto);
            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;
            var datos = _mapper.Map<IEnumerable<ObtenerProyectoPaginadoResponseViewModel>>(result);

            dtProyectoPaginadoResponseViewModel data = new dtProyectoPaginadoResponseViewModel
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