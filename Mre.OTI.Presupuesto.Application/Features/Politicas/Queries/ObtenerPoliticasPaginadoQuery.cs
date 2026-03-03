using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Calendario.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Calendario;
using Mre.OTI.Presupuesto.Application.Responses.Politicas;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Politicas.Queries
{
    public class ObtenerPoliticasPaginadoQuery : IRequestHandler<ObtenerPoliticasPaginadoViewModel, dtPoliticasPaginadoResponseViewModel>
    {
        readonly private IPoliticasRepository _IPoliticasRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerPoliticasPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IPoliticasRepository IPoliticasRepository, IMapper mapper)
        {
            _IPoliticasRepository = IPoliticasRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }

        public async Task<dtPoliticasPaginadoResponseViewModel> Handle(ObtenerPoliticasPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = PoliticasMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IPoliticasRepository.ObtenerPoliticasPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerPoliticasPaginadoResponseViewModel>>(result);

            dtPoliticasPaginadoResponseViewModel data = new dtPoliticasPaginadoResponseViewModel
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
