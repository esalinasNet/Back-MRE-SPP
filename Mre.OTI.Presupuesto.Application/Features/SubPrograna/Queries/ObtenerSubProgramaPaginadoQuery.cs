using AutoMapper;
using MediatR;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.Programa;
using Mre.OTI.Presupuesto.Application.Responses.SubPrograma;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mre.OTI.Presupuesto.Application.Features.SubPrograna.Queries
{
    public class ObtenerSubProgramaPaginadoQuery : IRequestHandler<ObtenerSubProgramaPaginadoViewModel, dtSubProgramaPaginadoResponseViewModel>
    {
        readonly private ISubProgramaRepository _ISubProgramaRepository;
        private readonly IMapper _mapper;
        readonly private IUsuarioRolRepository _IUsuarioRolRepository;
        public ObtenerSubProgramaPaginadoQuery(IUsuarioRolRepository IIUsuarioRolRepository, ISubProgramaRepository ISubProgramaRepository, IMapper mapper)
        {
            _ISubProgramaRepository = ISubProgramaRepository;
            _mapper = mapper;
            _IUsuarioRolRepository = IIUsuarioRolRepository;
        }
        public async Task<dtSubProgramaPaginadoResponseViewModel> Handle(ObtenerSubProgramaPaginadoViewModel request, CancellationToken cancellationToken)
        {
            var dto = SubProgramaMap.MaptoDTO(request);
            if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
            if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

            var result = await _ISubProgramaRepository.ObtenerSubProgramaPaginado(dto);

            var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

            var datos = _mapper.Map<IEnumerable<ObtenerSubProgramaPaginadoResponseViewModel>>(result);

            dtSubProgramaPaginadoResponseViewModel data = new dtSubProgramaPaginadoResponseViewModel
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
