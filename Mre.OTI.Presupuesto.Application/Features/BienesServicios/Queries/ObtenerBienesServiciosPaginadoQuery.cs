using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.BienesServicios;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Mre.OTI.Presupuesto.Application.Features.BienesServicios.Queries
{
    public class ObtenerBienesServiciosPaginadoQuery : IRequestHandler<ObtenerBienesServiciosPaginadoViewModel, dtBienesServiciosPaginadoResponseViewModel>
    {
        readonly private IBienesServiciosRepository _IBienesServiciosRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerBienesServiciosPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IBienesServiciosRepository IBienesServiciosRepository, IMapper mapper)
        {
            _IBienesServiciosRepository = IBienesServiciosRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtBienesServiciosPaginadoResponseViewModel> Handle(ObtenerBienesServiciosPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = BienesServiciosMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IBienesServiciosRepository.ObtenerBienesServiciosPaginado(dto);


            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerBienesServiciosPaginadoResponseViewModel>>(result);

            dtBienesServiciosPaginadoResponseViewModel data = new dtBienesServiciosPaginadoResponseViewModel
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
