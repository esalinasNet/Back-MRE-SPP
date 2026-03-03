using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries
{
    public class ObtenerUbigeoPaginadoQuery : IRequestHandler<ObtenerUbigeoPaginadoViewModel, dtUbigeoPaginadoResponseViewModel>
    {
        readonly private IUbigeoRepository _IUbigeoRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerUbigeoPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IUbigeoRepository IUbigeoRepository, IMapper mapper)
        {
            _IUbigeoRepository = IUbigeoRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtUbigeoPaginadoResponseViewModel> Handle(ObtenerUbigeoPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = UbigeoMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IUbigeoRepository.ObtenerUbigeoPaginado(dto);


            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerUbigeoPaginadoResponseViewModel>>(result);

            dtUbigeoPaginadoResponseViewModel data = new dtUbigeoPaginadoResponseViewModel
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
