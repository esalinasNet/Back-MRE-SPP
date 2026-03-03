using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Anios.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Anios;
using Mre.OTI.Presupuesto.Application.Responses.Anios;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Anios.Queries
{
    public class ObtenerAniosPaginadoQuery : IRequestHandler<ObtenerAniosPaginadoViewModel, dtAniosPaginadoResponseViewModel>
    {
        readonly private IAniosRepository _IAniosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerAniosPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAniosRepository IAniosRepository, IMapper mapper)
        {
            _IAniosRepository = IAniosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<dtAniosPaginadoResponseViewModel> Handle(ObtenerAniosPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = AniosMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IAniosRepository.ObtenerAniosPaginado(dto);


            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerAniosPaginadoResponseViewModel>>(result);

            dtAniosPaginadoResponseViewModel data = new dtAniosPaginadoResponseViewModel
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
