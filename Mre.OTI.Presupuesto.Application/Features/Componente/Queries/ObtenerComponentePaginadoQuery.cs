using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Componente.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Componente;
using Mre.OTI.Presupuesto.Application.Responses.Componente;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Componente.Queries
{
    public class ObtenerComponentePaginadoQuery : IRequestHandler<ObtenerComponentePaginadoViewModel, dtComponentePaginadoResponseViewModel>
    {
        readonly private IComponenteRepository _IComponenteRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerComponentePaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IComponenteRepository IComponenteRepository, IMapper mapper)
        {
            _IComponenteRepository = IComponenteRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<dtComponentePaginadoResponseViewModel> Handle(ObtenerComponentePaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = ComponenteMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IComponenteRepository.ObtenerComponentePaginado(dto);


            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerComponentePaginadoResponseViewModel>>(result);

            dtComponentePaginadoResponseViewModel data = new dtComponentePaginadoResponseViewModel
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
