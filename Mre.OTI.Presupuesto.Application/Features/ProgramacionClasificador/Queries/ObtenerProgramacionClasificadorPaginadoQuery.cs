using AutoMapper;
using Mre.OTI.Presupuesto.Application.Exceptions;
using Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Queries;
using Mre.OTI.Presupuesto.Application.Mapper;
using Mre.OTI.Presupuesto.Application.Repositories;
using Mre.OTI.Presupuesto.Application.Responses.ProgramacionClasificador;
using Mre.OTI.Presupuesto.Application.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using MediatR;

namespace Mre.OTI.Presupuesto.Application.Features.ProgramacionClasificador.Queries
{
    public class ObtenerProgramacionClasificadorPaginadoQuery : IRequestHandler<ObtenerProgramacionClasificadorPaginadoViewModel, dtProgramacionClasificadorPaginadoResponseViewModel>
    {
        private readonly IProgramacionClasificadorRepository _IProgramacionClasificadorRepository;
    private readonly IMapper _mapper;
    private readonly IUsuarioRolRepository _IUsuarioRolRepository;

    public ObtenerProgramacionClasificadorPaginadoQuery(IUsuarioRolRepository IUsuarioRolRepository, IProgramacionClasificadorRepository IProgramacionClasificadorRepository, IMapper mapper)
    {
        _IProgramacionClasificadorRepository = IProgramacionClasificadorRepository;
        _mapper = mapper;
        _IUsuarioRolRepository = IUsuarioRolRepository;
    }

    public async Task<dtProgramacionClasificadorPaginadoResponseViewModel> Handle(ObtenerProgramacionClasificadorPaginadoViewModel request, CancellationToken cancellationToken)
    {
        var dto = ProgramacionClasificadorMap.MaptoDTO(request);

        if (request.paginaActual == 0) throw new MreException(Constantes.MensajesError.PAGINA_ACTUAL_VALIDAR);
        if (request.tamanioPagina == 0) throw new MreException(Constantes.MensajesError.TAMAÑO_PAGINA_VALIDAR);

        var result = await _IProgramacionClasificadorRepository.ObtenerProgramacionClasificadorPaginado(dto);

        var recordsTotal = result.Any() ? result.FirstOrDefault().totalRegistro : 0;

        var datos = _mapper.Map<IEnumerable<ObtenerProgramacionClasificadorPaginadoResponseViewModel>>(result);

        dtProgramacionClasificadorPaginadoResponseViewModel data = new dtProgramacionClasificadorPaginadoResponseViewModel
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
