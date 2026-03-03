using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Paises.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Paises;
using Mre.OTI.Presupuesto.Application.Responses.Paises;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Paises.Queries
{
    public class ObtenerPaisesPaginadoQuery : IRequestHandler<ObtenerPaisesPaginadoViewModel, dtPaisesPaginadoResponseViewModel>
    {
        readonly private IPaisesRepository _IPaisesRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerPaisesPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPaisesRepository IPaisesRepository, IMapper mapper)
        {
            _IPaisesRepository = IPaisesRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<dtPaisesPaginadoResponseViewModel> Handle(ObtenerPaisesPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = PaisesMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IPaisesRepository.ObtenerPaisesPaginado(dto);


            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerPaisesPaginadoResponseViewModel>>(result);

            dtPaisesPaginadoResponseViewModel data = new dtPaisesPaginadoResponseViewModel
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
