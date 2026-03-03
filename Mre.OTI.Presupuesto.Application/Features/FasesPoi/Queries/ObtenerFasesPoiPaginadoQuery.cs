using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Acciones.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Acciones;
using Mre.OTI.Presupuesto.Application.Responses.FasesPoi;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.FasesPoi.Queries
{
    public class ObtenerFasesPoiPaginadoQuery : IRequestHandler<ObtenerFasesPoiPaginadoViewModel, dtFasesPoiPaginadoResponseViewModel>
    {
        readonly private IFasesPoiRepository _IFasesPoiRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerFasesPoiPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IFasesPoiRepository IFasesPoiRepository, IMapper mapper)
        {
            _IFasesPoiRepository = IFasesPoiRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtFasesPoiPaginadoResponseViewModel> Handle(ObtenerFasesPoiPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = FasesPoiMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IFasesPoiRepository.ObtenerFasesPoiPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerFasesPoiPaginadoResponseViewModel>>(result);

            dtFasesPoiPaginadoResponseViewModel data = new dtFasesPoiPaginadoResponseViewModel
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
