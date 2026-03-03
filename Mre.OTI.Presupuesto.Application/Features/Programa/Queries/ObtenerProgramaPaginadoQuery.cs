using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.Funcion.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Funcion;
using Mre.OTI.Presupuesto.Application.Responses.Programa;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.Programa.Queries
{
    public class ObtenerProgramaPaginadoQuery : IRequestHandler<ObtenerProgramaPaginadoViewModel, dtProgramaPaginadoResponseViewModel>
    {
        readonly private IProgramaRepository _IProgramaRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerProgramaPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, IProgramaRepository IProgramaRepository, IMapper mapper)
        {
            _IProgramaRepository = IProgramaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<dtProgramaPaginadoResponseViewModel> Handle(ObtenerProgramaPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = ProgramaMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _IProgramaRepository.ObtenerProgramaPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerProgramaPaginadoResponseViewModel>>(result);

            dtProgramaPaginadoResponseViewModel data = new dtProgramaPaginadoResponseViewModel
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
