using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Sistema.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Sistema;
using Mre.OTI.Presupuesto.Application.Responses.Sistema;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Sistema.Queries
{
    public class ObtenerSistemaPaginadoQuery : IRequestHandler<ObtenerSistemaPaginadoViewModel, dtSistemaPaginadoResponseViewModel>
    {
        readonly private ISistemaRepository _ISistemaRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerSistemaPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, ISistemaRepository ISistemaRepository, IMapper mapper)
        {
            _ISistemaRepository = ISistemaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtSistemaPaginadoResponseViewModel> Handle(ObtenerSistemaPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = SistemaMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _ISistemaRepository.ObtenerSistemaPaginado(dto);


            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerSistemaPaginadoResponseViewModel>>(result);

            dtSistemaPaginadoResponseViewModel data = new dtSistemaPaginadoResponseViewModel
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
