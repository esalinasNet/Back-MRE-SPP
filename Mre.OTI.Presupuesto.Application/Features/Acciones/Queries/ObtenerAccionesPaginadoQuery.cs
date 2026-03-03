using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Objetivos.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.Objetivos;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Acciones.Queries
{
    public class ObtenerAccionesPaginadoQuery : IRequestHandler<ObtenerAccionesPaginadoViewModel, dtAccionesPaginadoResponseViewModel>
    {
        readonly private IAccionesRepository _IAccionesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerAccionesPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IAccionesRepository IAccionesRepository, IMapper mapper)
        {
            _IAccionesRepository = IAccionesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtAccionesPaginadoResponseViewModel> Handle(ObtenerAccionesPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = AccionesMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IAccionesRepository.ObtenerAccionesPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerAccionesPaginadoResponseViewModel>>(result);

            dtAccionesPaginadoResponseViewModel data = new dtAccionesPaginadoResponseViewModel
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
