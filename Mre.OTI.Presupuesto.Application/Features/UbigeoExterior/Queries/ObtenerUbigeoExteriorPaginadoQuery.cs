using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Ubigeo.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Ubigeo;
using Mre.OTI.Presupuesto.Application.Responses.UbigeoExterior;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.UbigeoExterior.Queries
{
    internal class ObtenerUbigeoExteriorPaginadoQuery : IRequestHandler<ObtenerUbigeoExteriorPaginadoViewModel, dtUbigeoExteriorPaginadoResponseViewModel>
    {
        readonly private IUbigeoExteriorRepository _IUbigeoExteriorRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerUbigeoExteriorPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IUbigeoExteriorRepository IUbigeoExteriorRepository, IMapper mapper)
        {
            _IUbigeoExteriorRepository = IUbigeoExteriorRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtUbigeoExteriorPaginadoResponseViewModel> Handle(ObtenerUbigeoExteriorPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = UbigeoExteriorMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IUbigeoExteriorRepository.ObtenerUbigeoExteriorPaginado(dto);


            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerUbigeoExteriorPaginadoResponseViewModel>>(result);

            dtUbigeoExteriorPaginadoResponseViewModel data = new dtUbigeoExteriorPaginadoResponseViewModel
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
